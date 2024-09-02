using Godot;
using PorygonC.Domain;
using System;

public partial class SceneNode : Node3D
{
	public Scene Identity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Identity.Deleted += (target)=>{
			foreach (var child in GetChildren())
			{
				if (child is PokemonNode){
					var pokemonNode = (PokemonNode)child;
					GD.Print(pokemonNode.Identity);
					if( pokemonNode.Identity != target) continue;
					
					RemoveChild(pokemonNode);
					pokemonNode.QueueFree();
				}
			}
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
