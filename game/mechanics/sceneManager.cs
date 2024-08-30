using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Domain;
using PorygonC.Scenes.Infrastructure;
using PorygonC.Trainers.Domain;

public static class SceneNodeManager
{
    public static void InitializeSceneNode(Node3D node,Trainer player, Trainer opponent)
    {
        SceneManager.InitializeScene(player,opponent);
		
		Node3D scene = (Node3D)GD.Load<PackedScene>("res://Game/Mechanics/scene.tscn").Instantiate();
		node.AddChild(scene);
		scene.Position += new Vector3 (0,2,0);

        string[] PATH = {"res://Game/Graphics/Pokemon/Back/", "res://Game/Graphics/Pokemon/Front/"};
		Vector3[] POS = [new Vector3(-0.7f,0,0.5f), new Vector3(0.7f,0,-0.5f)];

		var pokemonList = SceneManager.Scene.PokemonsPlayerGroup.Concat(SceneManager.Scene.PokemonsOpponentGroup);
		foreach (var pokemon in pokemonList)
		{
			var value = SceneManager.Scene.PokemonsPlayerGroup.Contains(pokemon) ? 0 : 1;
			var pokemonNode = (PokemonNode)GD.Load<PackedScene>("res://Game/Mechanics/Pokemon/pokemonNode.tscn").Instantiate();
			pokemonNode.Identity = pokemon;
			scene.AddChild(pokemonNode);
			pokemonNode.Position += POS[value];
			POS[value] += new Vector3(1f,0,0);

			pokemonNode.GetChild<Label3D>(2).Text = pokemon.Name;
			
			
			var sprite = pokemonNode.GetChild<PokemonSprite3D>(0);
			sprite.Assign(pokemon.Key, value == 0 ? Orientation.BACK : Orientation.FRONT);
			
			CollisionShapeHelper.AdjustCollisionShapeToSprite(pokemonNode);
		}
		SceneUi.Load(SceneManager.Scene,scene);
    }
}

public static class SceneUi
{
	public static void Load(Scene scene, Node3D node)
	{
		Control ilast = null;
		Control iinit = null;
		foreach (var pkm in scene.PokemonsPlayerGroup)
		{
			Control menu = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/overlay_fight.tscn").Instantiate();
			int @in = 0;
			foreach ( var child in menu.GetChildren()){
				if (!(child is Button)) continue;
				var button = (Button)child;
				var n = @in;
				button.Text = pkm.Moves[n].ToString();
				var last = ilast;
				if(last == null){
					iinit = menu;
					button.Pressed += () => {
						pkm.CurrMove = pkm.Moves[n];
						scene.InitializeTurn();
						menu.Visible = false;
					};	
				}
				else{
					last.Visible = false;
					button.Pressed += () => {
						pkm.CurrMove = pkm.Moves[n];
						last.Visible = true;
						menu.Visible = false;
					};	
				}				
				@in++;
			}
			ilast = menu;
			node.AddChild(menu);
			
		}

	}
}
public static class SpriteHelper
{
	public static void AnimatedSprite(Sprite3D sprite)
	{
		var cap = sprite.Texture.GetWidth() / sprite.Texture.GetHeight();
		sprite.Hframes = cap;
		Tween tween = sprite.GetTree().CreateTween().SetLoops();
		
		tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
		tween.TweenCallback(Callable.From(() => sprite.Frame = 0));
	}
	public static void AnimatedSprite(Sprite2D sprite)
	{
		var cap = sprite.Texture.GetWidth() / sprite.Texture.GetHeight();
		sprite.Hframes = cap;
		Tween tween = sprite.GetTree().CreateTween().SetLoops();
		tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
		tween.TweenCallback(Callable.From(() => sprite.Frame = 0));
	}
}
public static class CollisionShapeHelper
{
	public static void AdjustCollisionShapeToSprite(Node3D node)
	{	
		var image = node.GetNode<Sprite3D>("PokemonSprite3D").Texture.GetImage();
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

        	var boxShape = new BoxShape3D
        	{
            	Size = new Vector3(width, height, 0.1f) // El tercer valor es la profundidad del box
        	};

        	// Asignar la forma de colisión al CollisionShape3D
        	var collisionShape = node.GetNode<CollisionShape3D>("CollisionShape3D");
        	collisionShape.Shape = boxShape;

        	var Y = (minY / 100f) + (height / 2) - (box / 100f / 2);
			var X = (minX / 100f) + (width / 2) - (box / 100f / 2);
			collisionShape.Position = new Vector3(-X , -Y, 0);
			
	}
}