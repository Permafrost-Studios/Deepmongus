using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	[Export] float moveSpeed = 300f;
	[Export] float jumpSpeed = 500f;
	[Export] float jumpTime = 0.1f;
	float remainingJumpTime;

	bool isJumping = false;

	bool facingRight = false; //Make sure he is facing right by default

	float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	Vector2 newVel;

	Sprite2D thisSprite;

	public override void _Ready() 
	{
		remainingJumpTime = jumpTime;

		thisSprite = this.GetNode("./Sprite") as Sprite2D;
	}

	public override void _PhysicsProcess(double delta) 
	{
		newVel.X = this.Velocity.X;

		float horizontalInput = Input.GetAxis("Left", "Right");
		newVel.X = horizontalInput * moveSpeed;

		if (horizontalInput < 0 && facingRight || horizontalInput > 0 && !facingRight) 
		{
			Flip();
		}

		if (isJumping) 
		{
			// newVel.Y = -jumpSpeed;
			remainingJumpTime -= (float)delta;

			if (remainingJumpTime <= 0) 
			{
				isJumping = false;
				remainingJumpTime = jumpTime;
			}

			if (this.IsOnCeiling()) 
			{
				isJumping = false;

				GD.Print("stopped jumping");
			}
		}
		else 
		{
			newVel.Y += Gravity * (float)delta;
		}

		this.Velocity = newVel;
		this.MoveAndSlide();
	}

	public override void _Input(InputEvent @event) 
	{
		if(Input.IsActionJustPressed("Jump") && this.IsOnFloor())
		{
			GD.Print("Jump");
			isJumping = true;
			remainingJumpTime = jumpTime;
			newVel.Y = -jumpSpeed; //Positive direction is downwards
		}
	}

	void Flip() 
	{
		thisSprite.FlipH = !thisSprite.FlipH;
		facingRight = !facingRight;
	}
}
