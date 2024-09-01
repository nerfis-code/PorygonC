using Godot;
using PorygonC.Pokemons.Application;
using PorygonC.Pokemons.Domain;
using System;
using System.Threading.Tasks;

public partial class bg_skills : Control
{
	// Called when the node enters the scene tree for the first time.
	public Pokemon Identity;
	private Task action;
	
	const string PATH = "res://Game/Graphics/Pokemon/Front/";
	public override void _Ready()
	{
		_Update();
	}
	public void _Update()
	{
		if (Identity == null) return ;
		//sprite
		var img = GD.Load<Texture2D>(PATH+Identity.Key.ToString()+".png");
		GetNode<PokemonSprite2D>("Sprite2D").Assign(Identity.Key,PATH);

		//info
		GetNode<Label>("Name").Text = Identity.Name;
		GetNode("Stats").GetNode<Label>("Ps").Text = Identity.Stats[0].ToString() + "/" + Identity.Ps.ToString();
		async Task task(){
			GetNode("Stats").GetNode<Label>("Ps").Text = Identity.Stats[0].ToString() + "/" + Identity.Ps.ToString();
			await AnimatedProgressBar.Animate(GetNode<ProgressBar>("HP"),Identity.Ps);
		};
		action = task();
		Identity.Received += task;
		//#18C020
		GetNode<ProgressBar>("HP").MaxValue = Identity.Stats[0];
		GetNode<ProgressBar>("HP").Value = Identity.Ps;
		GetNode("Stats").GetNode<Label>("Attk").Text = Identity.Stats[1].ToString();
		GetNode("Stats").GetNode<Label>("Def").Text = Identity.Stats[2].ToString();
		GetNode("Stats").GetNode<Label>("SpAttk").Text = Identity.Stats[4].ToString();
		GetNode("Stats").GetNode<Label>("SpDef").Text = Identity.Stats[5].ToString();
		GetNode("Stats").GetNode<Label>("Spd").Text = Identity.Stats[3].ToString();
	}

	public override void _ExitTree()
	{
		async Task task(){
			GetNode("Stats").GetNode<Label>("Ps").Text = Identity.Stats[0].ToString() + "/" + Identity.Ps.ToString();
			await AnimatedProgressBar.Animate(GetNode<ProgressBar>("HP"),Identity.Ps);
		};
		Identity.Received -= task;
		base._ExitTree();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
