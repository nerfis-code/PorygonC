using Godot;
using System;
using PorygonC.Pokemons.Domain;
using PorygonC.Pokemons.Application;
using PorygonC.Scenes.Domain;
using PorygonC.Scenes.Application;
using System.IO;
using PorygonC.Species.Domain;
using Utf8Json;

using System.Collections.Generic;
using PorygonC.Scenes.Infrastructure;
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
		SceneManager.Main(this);
		

	}
	
}
