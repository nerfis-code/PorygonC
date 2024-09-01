using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;
using PorygonC.Moves.Domain;
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
			pokemonNode.scene = SceneManager.Scene;
			scene.AddChild(pokemonNode);
			pokemonNode.Position += POS[value];
			POS[value] += new Vector3(1.2f,0,0);
		}
		SceneUi.Load(SceneManager.Scene,scene);

		async Task ShowTextAction(Move move, Pokemon user)
		{
			var overlay_message = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/overlay_message.tscn").Instantiate();
			var text = overlay_message.GetNode<RichTextLabel>("RichTextLabel");
			text.PushColor(Color.Color8(205,92,92));
			text.AppendText(user.Name);
			text.Pop();
			text.AppendText(" Ha realizado el movimiento ");
			text.PushColor(Color.Color8(65,105,225));
			text.AppendText(move.Name);
			text.Pop();
			text.VisibleRatio = 0;
			scene.AddChild(overlay_message);

			var tween = text.CreateTween();
			tween.TweenProperty(text,"visible_ratio",1,2);
			await Task.Delay(3000);
			scene.RemoveChild(overlay_message);
		}
		async Task ShowTextRecived(Move move, Pokemon target, short received)
		{
			var overlay_message = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/overlay_message.tscn").Instantiate();
			var text = overlay_message.GetNode<RichTextLabel>("RichTextLabel");
			text.AppendText("[color=green]" + target.Name + "[/color] Ha recibido " + "[color=red][font_size=25]"+ received + "[/font_size][/color] Gracia Al movimiento " + "[color=blue]" + move.Name + "[/color]");
			text.VisibleRatio = 0;
			await Task.Delay(3000);
			scene.AddChild(overlay_message);

			var tween = text.CreateTween();
			tween.TweenProperty(text,"visible_ratio",1,2);
			await Task.Delay(3000);
			scene.RemoveChild(overlay_message);
		}
		SceneManager.Scene.OnAction += ShowTextAction;
		SceneManager.Scene.OnReceived += ShowTextRecived;
    }
	
}

