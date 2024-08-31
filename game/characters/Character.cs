using Godot;
using PorygonC.Trainers.Domain;
using System;

public partial class Character : CharacterBody3D
{
	public const float Speed = 1.0f;
	public const float JumpVelocity = 4.5f;
	public MachineState State;
	public Trainer Trainer;
	private Area3D Observer;

	public override void _Ready()
	{
		base._Ready();
		State = new MachineState(GetNode<AnimatedSprite3D>("AnimatedSprite3D"));
		Observer  = GetNode<Area3D>("Area3D");
		
	}
	private PokemonNode CheckCollisions()
	{

		var a  = Observer.GetOverlappingBodies();
		foreach (var item in a)
		{
			if(item is PokemonNode) return (PokemonNode)item;
		}
		return null;
	}
	private void Sumary(){
		var Touch = CheckCollisions();
		if (Touch != null){
			
			if (GetParent().HasNode("bg_skills"))
			{
				var node = GetParent().GetNode<bg_skills>("bg_skills");
				if (node.Identity == Touch.Identity) return ;
				GetParent().RemoveChild(node);
				node.QueueFree();
			}
			var Sumary = (bg_skills)GD.Load<PackedScene>("res://Game/Mechanics/Menus/bg_skills.tscn").Instantiate();
			Sumary.Identity = Touch.Identity;
			GetParent().AddChild(Sumary);
			
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		
		
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("ui_exit")){
			if (GetParent().HasNode("bg_skills"))
			{
				var node = GetParent().GetNode<bg_skills>("bg_skills");
				GetParent().RemoveChild(node);
				node.QueueFree();
			}
		}
		if (Input.IsActionJustPressed("ui_accept")){
			Sumary();
		}

		// Handle Jump.
		/**if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}**/

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		//AnimatedSprite3D animatedSprite = GetNode<AnimatedSprite3D>("AnimatedSprite3D");
		
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;

			if (direction.Z != 0)
			{
				if (direction.Z > 0) {
					State.Run("front");
					Observer.Rotation = new Vector3(0,180,0);
				}
				else {
					State.Run("back");
					Observer.Rotation = new Vector3(0,0,0);	
				}
			}
			else
			{
				if (direction.X > 0) {
					State.Run("right");
					Observer.Rotation = new Vector3(0,-90,0);	
				}
				else {
					State.Run("left");
					Observer.Rotation = new Vector3(0,90,0);
				}
			}
			
		}
		else
		{
			State.Stop();
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

public class MachineState
{
	public string State { get; set;}
	public AnimatedSprite3D Sprite { get; set; }

	public MachineState(AnimatedSprite3D node)
	{
		Sprite = node;
	}

	public void Run(string state)
	{
		if(State != state)
		{
			State = state;
			Sprite.Play(State);
		}
	}

	public void Stop()
	{
		State = null;
		Sprite.Stop();
	}
}
