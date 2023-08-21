using Godot;
using System;

public enum resourceType {

}

public partial class PlayerController : CharacterBody2D
{
	[Export] float moveSpeed = 100f;
	[Export] float jumpSpeed = 50f;
	[Export] float jumpTime = 1f;
	float remainingJumpTime;

	bool isJumping = false;

	bool facingRight = false; //Make sure he is facing right by default

	float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	Vector2 newVel;

	public override void _PhysicsProcess(double delta) 
	{
		newVel = this.Velocity;

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
			newVel.Y += Gravity * (float)delta;
		}

		float horizontalInput = Input.GetAxis("Left", "Right");
		newVel.X = (facingRight ? 1 : -1) * moveSpeed;

		this.Velocity = newVel;
		this.MoveAndSlide();
	}

	public override void _Input(InputEvent @event) 
	{
		if(@event.IsActionPressed("Jump"))
		{
			isJumping = true;
			remainingJumpTime = jumpTime;
			newVel.Y = -jumpSpeed; //Positive direction is downwards
		}
	}
}
