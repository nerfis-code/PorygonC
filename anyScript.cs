using Godot;
using System;
using System.IO;
using Utf8Json;
using System.Collections.Generic;
using System.Linq;
   
using PorygonC.Domain;
using PorygonC.Application;
using PorygonC.Infrastructure;

public partial class anyScript : Node3D{
	public override void _Ready(){

		var player = new Trainer("Nerfis");
		var oponent = new Trainer("Eliezer");

		
		PokemonConstructor pkc = new PokemonConstructor{};
		player.AddPokemonsToTeam(new PokemonKey[] {PokemonKey.PIKACHU,PokemonKey.AERODACTYL,PokemonKey.BULBASAUR}.Select(n => pkc.Create((int)n)).ToArray());
		oponent.AddPokemonsToTeam(new PokemonKey[] {PokemonKey.GIRATINA,PokemonKey.POLTEAGEIST,PokemonKey.MEW}.Select(n => pkc.Create((int)n)).ToArray());
		SceneNodeManager.InitializeSceneNode(this,player,oponent);
		
		GD.Print(new Move(MoveKey.DARKPULSE).Description);
	}
	
}
