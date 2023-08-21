using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	[Export] float moveSpeed = 100f;
	[Export] float jumpSpeed = 50f;
	[Export] float jumpTime = 1f;
	float remainingJumpTime;

	bool isJumping = false;

	bool facingRight = true; //Make sure he is facing right by default

	float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta) 
	{
		Vector2 velocity = this.Velocity;

		//Jumping behaviour
		if(Input.IsActionJustPressed("Jump")  && this.IsOnFloor())
		{
			isJumping = true;
			remainingJumpTime = jumpTime;
			velocity.Y = -jumpSpeed; //Positive direction is downwards
		} 

		if (isJumping) 
		{
			remainingJumpTime -= (float)delta;

			if (remainingJumpTime <= 0) 
			{
				isJumping = false;
			}
		}
		else 
		{
			velocity.Y += Gravity * (float)delta;
		}

		float horizontalInput = Input.GetAxis("Left", "Right");
		velocity.X = (facingRight ? 1 : -1) * moveSpeed;

		this.Velocity = velocity;
		this.MoveAndSlide();
	}

	public override void _Input(InputEvent @event) 
	{
		// if(@event.IsActionPressed("Jump"))
		// {

		// }
	}
}
