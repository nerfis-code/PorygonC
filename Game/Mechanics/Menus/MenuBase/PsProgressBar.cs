using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class PsProgressBar : TextureProgressBar
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	Texture2D Texture;
	enum Status{
		Green,
		Yellow,
		Red
	}

	public override void _Ready()
	{
		if(Texture == null) return;
		var atlas = new AtlasTexture
		{
			Atlas = Texture,
			Region = new Rect2(0, 0, Texture.GetWidth()-5, Texture.GetHeight() / 3)
		};
		TextureProgress = atlas;
	}
	public async Task AssingPs(int newPs){
		//green -> 0 yellow -> 1 red -> 2
		var tween = CreateTween();
		var time = Math.Min(2,Math.Abs(Value - newPs)*0.1);
		tween.TweenProperty(this,"value",newPs,time).SetEase(Tween.EaseType.Out);
		await Task.Delay((int)(time*1000) + 500);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var curr = Value >= 0.5*MaxValue ? Status.Green : Value >= 0.3*MaxValue ? Status.Yellow : Status.Red;
		var atlas = new AtlasTexture
		{
			Atlas = Texture,
			Region = new Rect2(0, (int)curr*(Texture.GetHeight() / 3), Texture.GetWidth()-5, Texture.GetHeight() / 3)
		};
		TextureProgress = atlas;
	}
}
