using System;
using System.Linq;
using Godot;
using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Infrastructure;
using PorygonC.Trainers.Domain;

public static class SceneManager
{
    public static void Main(Node3D node,Trainer player, Trainer opponent)
    {
        InitScene.Main(player,opponent);
		
		Node3D scene = (Node3D)GD.Load<PackedScene>("res://game/mechanics/scene.tscn").Instantiate();
		node.AddChild(scene);
		scene.Position += new Vector3 (0,2,0);

        string[] PATH = {"res://game/Pokemon/Back/", "res://game/Pokemon/Front/"};
		Vector3[] POS = [new Vector3(-0.7f,0,0.5f), new Vector3(0.7f,0,-0.5f)];

		var pokemonList = InitScene.scene.PokemonsPlayerGroup.Concat(InitScene.scene.PokemonsOpponentGroup);

		foreach (var pokemon in pokemonList)
		{
			var value = InitScene.scene.PokemonsPlayerGroup.Contains(pokemon) ? 0 : 1;
			var pokemonNode = (Node3D)GD.Load<PackedScene>("res://game/mechanics/pokemonNode.tscn").Instantiate();
			scene.AddChild(pokemonNode);
			pokemonNode.Position += POS[value];
			POS[value] += new Vector3(1f,0,0);

			pokemonNode.GetChild<Label3D>(2).Text = pokemon.Name;
			
			var img = GD.Load<Texture2D>(PATH[value]+pokemon.Key.ToString()+".png");
			int cap = img.GetWidth() / img.GetHeight();
			var sprite = pokemonNode.GetChild<Sprite3D>(0);
			sprite.Texture = img;
			sprite.Hframes = cap;
			BoxSize.Main(img.GetImage(),pokemonNode.GetChild<CollisionShape3D>(1));

			Tween tween = node.GetTree().CreateTween().SetLoops();
			tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
			tween.TweenCallback(Callable.From(() => {sprite.Frame = 0;}));
			
		}

    }
}

public static class BoxSize
{
	public static void Main(Image image,CollisionShape3D collisionShape)
	{
		int box = image.GetHeight();
		int minX = box;
		int minY = box;
		int maxX = 0;
		int maxY = 0;
		for (int y = 0; y < box; y++)
			{
				for (int x = 0; x < box; x++)
				{
					var color = image.GetPixel(x, y);
					if (color.A > 0) // Considerar solo píxeles no transparentes
					{
						minX = Math.Min(minX, x);
						minY = Math.Min(minY, y);
						maxX = Math.Max(maxX, x);
						maxY = Math.Max(maxY, y);
					}
				}
			}
			var width = (maxX - minX + 1) / 100f;
			var height = (maxY - minY + 1) / 100f;

			var boxShape = new BoxShape3D();
			boxShape.Size = new Vector3(width, height, 0.1f); // El tercer valor es la profundidad del box

			// Asignar la forma de colisión al CollisionShape3D
			collisionShape.Shape = boxShape;
			

			var Y = (minY / 100f) + (height / 2) - (box / 100f / 2);
			var X = (minX / 100f) + (width / 2) - (box / 100f / 2);
			collisionShape.Position = new Vector3(-X , -Y, 0);
	}
}