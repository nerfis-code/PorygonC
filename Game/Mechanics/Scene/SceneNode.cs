using Godot;
using PorygonC.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

public partial class SceneNode : Node3D
{
	public Scene Identity;
	Vector3[] POS = [new Vector3(-0.7f,0,0.5f), new Vector3(0.7f,0,-0.5f)];
	// Called when the node enters the scene tree for the first time.
	public void EntredPokemon(Pokemon pokemon){
		async Task ShowTextRecived(string txt)
		{
			var OverlayMessage = (OverlayMessage)GD.Load<PackedScene>("res://Game/Mechanics/Menus/OverlayMessage.tscn").Instantiate();
			OverlayMessage.Create(txt);
			AddChild(OverlayMessage);
			await OverlayMessage.WaitPressedKey();
			RemoveChild(OverlayMessage);
			OverlayMessage.QueueFree();
			
		}
		var value = Identity.Group0.Contains(pokemon) ? 0 : 1;
		var index = value == 0 ? Identity.Group0.IndexOf(pokemon) : Identity.Group1.IndexOf(pokemon);
		var pokemonNode = (PokemonNode)GD.Load<PackedScene>("res://Game/Mechanics/Pokemon/pokemonNode.tscn").Instantiate();
		pokemonNode.Identity = pokemon;
		pokemon.Send += ShowTextRecived;
		pokemonNode.scene = Identity;
		AddChild(pokemonNode);
		pokemonNode.Position += POS[value] + new Vector3(1.2f*index,0,0);
	}
	public override void _Ready()
	{
		foreach (var pokemon in Identity.Group0.Concat(Identity.Group1))
		{
			EntredPokemon(pokemon);
		}

		var UI = new SceneUI{
			Identity = this
		};
		UI.Action();

		Identity.Entred += EntredPokemon;
		Identity.Deleted += (target)=>{
			foreach (var child in GetChildren())
			{
				if (child is PokemonNode){
					var pokemonNode = (PokemonNode)child;
					if( pokemonNode.Identity != target) continue;
					
					RemoveChild(pokemonNode);
					pokemonNode.QueueFree();
				}
			}
		};
		Identity.Change += async (pokemon)=>{
			await UI.Party();
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
