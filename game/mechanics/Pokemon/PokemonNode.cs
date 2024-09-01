using Godot;
using PorygonC.Domain;
using PorygonC.Domain;
using System;
using System.Threading.Tasks;

public partial class PokemonNode : RigidBody3D 
{
	// Called when the node enters the scene tree for the first time.
	public Pokemon Identity;
	public Scene scene;
	
	public override void _Ready()
	{
		GetChild<Label3D>(2).Text = Identity.Name;
		var bar = GetNode("SubViewport").GetChild(0).GetChild<ProgressBar>(0);
		bar.MaxValue = Identity.Stats[0];
		bar.Value = Identity.Ps;
		async Task action(){
			await AnimatedProgressBar.Animate(bar,Identity.Ps);
		}
		Identity.Received += action;
					
		var sprite = GetChild<PokemonSprite3D>(0);
		sprite.Assign(Identity.Key, scene.PokemonsPlayerGroup.Contains(Identity) ? Orientation.BACK : Orientation.FRONT);
			
		CollisionShapeHelper.AdjustCollisionShapeToSprite(this);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
