using Godot;
using System;

public class PlayerSubmarineState : PlayerState 
{
    //Add shooting behaviour
    //Add superSpeed behaviour

    float speed = 100f;

    float fuelDepletionRate;

    public override void Enter(PlayerStateManager stateMgr) {}
    
    public override void Update(PlayerStateManager stateMgr, double delta)
    {
		stateMgr.Velocity = (new Vector2(stateMgr.horizontalInput, -stateMgr.verticalInput) * speed).LimitLength(speed);

		stateMgr.MoveAndSlide();

        stateMgr.DepleteFuel(fuelDepletionRate); //Depletes fuel ON TOP of what is depleted in the state manager
    }

    public override void PhysicsUpdate(PlayerStateManager stateMgr, double delta)
    {

    }

    public override void Exit(PlayerStateManager stateMgr) {}

    public override void Input(PlayerStateManager stateMgr, string eventName)
    {
        
    }
}