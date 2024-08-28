using System;
using Godot;
using PorygonC.Scenes.Infrastructure;

public static class SceneManager
{
    public static void Main(Node3D node)
    {
        InitScene.Main();
		
		Node3D scene = (Node3D)GD.Load<PackedScene>("res://game/mechanics/scene.tscn").Instantiate();
		node.AddChild(scene);
		scene.Position += new Vector3 (0,2,0);

		foreach (var pokemon in InitScene.scene.PokemonsPlayerGroup)
		{
			var pokemonNode = (Node3D)GD.Load<PackedScene>("res://game/mechanics/pokemonNode.tscn").Instantiate();
			scene.AddChild(pokemonNode);
			pokemonNode.Position += new Vector3(-0.5f,0,0.5f);
			var img = GD.Load<Texture2D>("res://game/Pokemon/Back/"+pokemon.Key.ToString()+".png");
			pokemonNode.GetChild<Label3D>(2).Text = pokemon.Name;
			BoxSize.Main(img.GetImage(),img.GetHeight(),pokemonNode.GetChild<CollisionShape3D>(1));
			int cap = img.GetWidth() / img.GetHeight();
			var sprite = pokemonNode.GetChild<Sprite3D>(0);
			sprite.Texture = img;
			sprite.Hframes = cap;

			Tween tween = node.GetTree().CreateTween().SetLoops();
			tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
			Callable any = Callable.From(() => {sprite.Frame = 0;});
			tween.TweenCallback(any);
			
		}

		foreach (var pokemon in InitScene.scene.PokemonsOpponentGroup)
		{
			var pokemonNode = (Node3D)GD.Load<PackedScene>("res://game/mechanics/pokemonNode.tscn").Instantiate();
			scene.AddChild(pokemonNode);
			pokemonNode.Position += new Vector3(0.5f,0,-0.5f);
			var img = GD.Load<Texture2D>("res://game/Pokemon/Front/"+pokemon.Key.ToString()+".png");
			pokemonNode.GetChild<Label3D>(2).Text = pokemon.Name;
			BoxSize.Main(img.GetImage(),img.GetHeight(),pokemonNode.GetChild<CollisionShape3D>(1));
			int cap = img.GetWidth() / img.GetHeight();
			var sprite = pokemonNode.GetChild<Sprite3D>(0);
			sprite.Texture = img;
			sprite.Hframes = cap;

			Tween tween = node.GetTree().CreateTween().SetLoops();
			tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
			Callable any = Callable.From(() => {sprite.Frame = 0;});
			tween.TweenCallback(any);
			
		}
    }
}

public static class BoxSize
{
	public static void Main(Image image,int box,CollisionShape3D collisionShape)
	{
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