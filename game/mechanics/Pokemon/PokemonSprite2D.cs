using Godot;
using PorygonC.Domain;

public partial class PokemonSprite2D : Sprite2D
{
	public Tween tween;
	public void Assign(PokemonKey key, string path)
	{
		var img = GD.Load<Texture2D>(path + key.ToString() + ".png");
		Texture = img;
		AnimatedSprite(this);
	}
	private void AnimatedSprite(Sprite2D sprite)
	{
		var cap = sprite.Texture.GetWidth() / sprite.Texture.GetHeight();
		sprite.Hframes = cap;
		tween = sprite.CreateTween().SetLoops();
		
		tween.TweenProperty(sprite,"frame",cap-1,cap*0.09);
		tween.TweenCallback(Callable.From(() => {
			if (IsInstanceValid(sprite))
			{
				sprite.Frame = 0;
			}
		}));
	}

	// Sobrescribir el método _ExitTree para asegurarnos de eliminar el tween si el nodo es removido
	public override void _ExitTree()
	{
		if (tween != null)
		{
			tween.Kill();
			tween = null;
		}
		base._ExitTree();
	}
}