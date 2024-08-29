using Godot;
using System;
using PorygonC.Pokemons.Domain;
using PorygonC.Pokemons.Application;
using PorygonC.Scenes.Domain;
using System.IO;
using PorygonC.Species.Domain;
using Utf8Json;

using System.Collections.Generic;
using PorygonC.Scenes.Infrastructure;
using PorygonC.Trainers.Domain;
using System.Linq;
public partial class anyScript : Node3D{
	public override void _Ready(){
		// var any = new PokemonConstructor{};
		// var alig = any.Main("PokemonsAliado1",50);
		// var alig2 = any.Main("PokemonsAliado2",70);
		// var opp = any.Main("PokemonsEnemigo1",40);
		// var scene = new ScenE{};
		// scene.AssigPlayerGroup([alig,alig2]);
		// scene.AssigOpponentGroup([opp]);
		// GameLoop.Main(scene);
		var player = new Trainer("Nerfis");
		var oponent = new Trainer("Eliezer");

		
		PokemonConstructor pkc = new PokemonConstructor{};
		player.AddPokemonsToTeam(new PokemonKey[] {PokemonKey.PIKACHU,PokemonKey.AERODACTYL}.Select(n => pkc.Create((int)n)).ToArray());
		oponent.AddPokemonsToTeam(new PokemonKey[] {PokemonKey.GIRATINA,PokemonKey.POLTEAGEIST}.Select(n => pkc.Create((int)n)).ToArray());
		SceneNodeManager.InitializeSceneNode(this,player,oponent);
		

	}
	
}
