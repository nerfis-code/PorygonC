using Godot;
using PorygonC.Pokemons.Domain;
using System;

public partial class PokemonNode : RigidBody3D 
{
	// Called when the node enters the scene tree for the first time.
	public Pokemon Identity;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
