using Godot;
using System;
using System.Threading.Tasks;

public partial class OverlayMessage : Control
{
	Tween _Tween;
	private TaskCompletionSource<bool> _keyPressCompletionSource;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void Create(string txt)
	{
		var child = GetNode<RichTextLabel>("RichTextLabel");
		child.AppendText(txt);
		child.VisibleRatio = 0;

		_Tween = CreateTween();
		_Tween.TweenProperty(child,"visible_ratio",1,2);
	}
	public async Task WaitPressedKey(){
		_keyPressCompletionSource = new TaskCompletionSource<bool>();
		await _keyPressCompletionSource.Task;
		
	}
	public override void _Input(InputEvent @event)
	{
		// Verificar si el evento de entrada es una tecla presionada
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			_Tween.Kill();
			if (GetNode<RichTextLabel>("RichTextLabel").VisibleRatio == 1){
				_keyPressCompletionSource?.TrySetResult(true);
			}
			GetNode<RichTextLabel>("RichTextLabel").VisibleRatio = 1;
			// Completar la tarea cuando la tecla se presiona
			

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
