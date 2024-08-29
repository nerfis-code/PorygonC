using Godot;
using PorygonC.Trainers.Domain;
using System;

public partial class Character : CharacterBody3D
{
	public const float Speed = 1.0f;
	public const float JumpVelocity = 4.5f;
	public MachineState State;
	public Trainer Trainer;

	public override void _Ready()
	{
		base._Ready();
		State = new MachineState(GetNode<AnimatedSprite3D>("AnimatedSprite3D"));
		
	}
	private PokemonNode CheckCollisions()
	{
		int collisionCount = GetSlideCollisionCount();
		for (int i = 0; i < collisionCount; i++)
		{
			KinematicCollision3D collision = GetSlideCollision(i);
			Node3D collider = collision.GetCollider() as Node3D;

			if (collider != null && collider is PokemonNode) return (PokemonNode)collider;
		}
		return null;
	}
	private void Sumary(){
		var Touch = CheckCollisions();
		if (Touch != null){
			
			if (GetParent().HasNode("bg_skills"))
			{
				var node = GetParent().GetNode<bg_skills>("bg_skills");
				if (node._Pokemon == Touch._Pokemon) return ;
				GetParent().RemoveChild(node);
				node.QueueFree();
			}
			var Sumary = (bg_skills)GD.Load<PackedScene>("res://game/mechanics/menus/bg_skills.tscn").Instantiate();
			Sumary._Pokemon = Touch._Pokemon;
			GetParent().AddChild(Sumary);
			
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		
		Sumary();
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		AnimatedSprite3D animatedSprite = GetNode<AnimatedSprite3D>("AnimatedSprite3D");
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;

			if (direction.Z != 0)
			{
				if (direction.Z > 0) State.Run("front");
				else State.Run("back");
			}
			else
			{
				if (direction.X > 0) State.Run("right");
				else State.Run("left");
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
