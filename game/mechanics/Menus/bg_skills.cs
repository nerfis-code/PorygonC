using Godot;
using PorygonC.Pokemons.Application;
using PorygonC.Pokemons.Domain;
using System;

public partial class bg_skills : Control
{
	// Called when the node enters the scene tree for the first time.
	public Pokemon _Pokemon;
	const string PATH = "res://Game/Graphics/Pokemon/Front/";
	public override void _Ready()
	{
		_Update();
	}
	public void _Update()
	{
		if (_Pokemon == null) return ;
		//sprite
		var img = GD.Load<Texture2D>(PATH+_Pokemon.Key.ToString()+".png");
		GetNode<Sprite2D>("Sprite2D").Texture = img;
		SpriteHelper.AnimatedSprite(GetNode<Sprite2D>("Sprite2D"));

		//info
		GetNode<Label>("Name").Text = _Pokemon.Name;
		GetNode<Label>("Ps").Text = _Pokemon.Stats[0].ToString() + "/" + _Pokemon.Ps.ToString();
		//#18C020
		GetNode<ProgressBar>("ProgressBar").MaxValue = _Pokemon.Stats[0];
		GetNode<ProgressBar>("ProgressBar").Value = _Pokemon.Ps;
		GetNode<Label>("Attk").Text = _Pokemon.Stats[1].ToString();
		GetNode<Label>("Def").Text = _Pokemon.Stats[2].ToString();
		GetNode<Label>("SpAttk").Text = _Pokemon.Stats[4].ToString();
		GetNode<Label>("SpDef").Text = _Pokemon.Stats[5].ToString();
		GetNode<Label>("Spd").Text = _Pokemon.Stats[3].ToString();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
