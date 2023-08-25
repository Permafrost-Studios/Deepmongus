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

	Area2D playerInteractArea;

    public override void Enter(PlayerStateManager stateMgr) 
    {
        stateMgr.cam.Zoom = new Vector2 (1, 1);

        stateMgr.currentCharacterBody = (CharacterBody2D)stateMgr.GetNode("./PlayerBody");

        remainingJumpTime = jumpTime;

		thisSprite = stateMgr.currentCharacterBody.GetNode("./Sprite") as Sprite2D;

		playerInteractArea = (Area2D)stateMgr.currentCharacterBody.GetNode("./InteractArea");
    }

    public override void Update(PlayerStateManager stateMgr, double delta) {}
    
    public override void PhysicsUpdate(PlayerStateManager stateMgr, double delta)
    {
        newVel.X = stateMgr.currentCharacterBody.Velocity.X;

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

			if (stateMgr.currentCharacterBody.IsOnCeiling()) 
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

		stateMgr.currentCharacterBody.Velocity = newVel;
		stateMgr.currentCharacterBody.MoveAndSlide();
    }

    public override void Exit(PlayerStateManager stateMgr) 
    {
        newVel = new Vector2();
    }

    public override void Input(PlayerStateManager stateMgr, InputEvent @event)
    {
        if(@event.IsActionPressed("Jump") && stateMgr.currentCharacterBody.IsOnFloor())
		{
            InitiateJump();
		}

        if(@event.IsActionPressed("Action") && stateMgr.currentCharacterBody.IsOnFloor())
		{
            MachineInteract();
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

    void MachineInteract() 
    {
        BaseMachine machine = (BaseMachine)playerInteractArea.GetOverlappingAreas()[0];

        GD.Print(machine.Name);

        machine.Activate(1);
    }
}