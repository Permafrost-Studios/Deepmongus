using Godot;
using System;

public class PlayerBodyState : PlayerState 
{
    float moveSpeed = 300f;
	float jumpSpeed = 700f;
	float jumpTime = 0.1f;
    float remainingJumpTime;

	bool isJumping = false;

	bool facingRight = false; //Make sure he is facing right by default

    float GravityMultiplier = 2f;
    float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    Vector2 newVel;

	Sprite2D thisSprite;

    public override void Enter(PlayerStateManager stateMgr) 
    {
        remainingJumpTime = jumpTime;

		thisSprite = stateMgr.GetNode("./Sprite") as Sprite2D;
    }

    public override void Update(PlayerStateManager stateMgr, double delta) {}
    
    public override void PhysicsUpdate(PlayerStateManager stateMgr, double delta)
    {
        newVel.X = stateMgr.Velocity.X;

		newVel.X = stateMgr.horizontalInput * moveSpeed;

		if (stateMgr.horizontalInput < 0 && facingRight || stateMgr.horizontalInput > 0 && !facingRight) 
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

			if (stateMgr.IsOnCeiling()) 
			{
				isJumping = false;

                newVel.Y = 0;

				GD.Print("stopped jumping");
			}
		}
		else 
		{
			newVel.Y += Gravity * GravityMultiplier * (float)delta;
		}

		stateMgr.Velocity = newVel;
		stateMgr.MoveAndSlide();
    }

    public override void Exit(PlayerStateManager stateMgr) 
    {
        newVel = new Vector2();
    }

    public override void Input(PlayerStateManager stateMgr, InputEvent @event)
    {
        if(@event.IsActionPressed("Jump") && stateMgr.IsOnFloor())
		{
            InitiateJump();
		}
    }

    void InitiateJump() 
    {
        isJumping = true;
        remainingJumpTime = jumpTime;
        newVel.Y = -jumpSpeed; //Positive direction is downwards
    }

    void Flip() 
	{
		thisSprite.FlipH = !thisSprite.FlipH;
		facingRight = !facingRight;
	}
}