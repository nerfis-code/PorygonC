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
			pokemonNode.scene = SceneManager.Scene;
			scene.AddChild(pokemonNode);
			pokemonNode.Position += POS[value];
			POS[value] += new Vector3(1.2f,0,0);
		}
		SceneUi.Load(SceneManager.Scene,scene);
    }
}

