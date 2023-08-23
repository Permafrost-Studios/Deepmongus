using Godot;
using System;

public class PlayerSubmarineState : PlayerState 
{
    //Add shooting behaviour
    //Add superSpeed behaviour

    float speed = 300f;
    float shootImpulse = 1200f;

    float fuelDepletionRate;

    Node2D shootPoint; // Use get child or something
    PackedScene Bullet = (PackedScene)GD.Load("res://Prefabs/missile.tscn");

    public override void Enter(PlayerStateManager stateMgr) 
    {
        shootPoint = (Node2D)stateMgr.GetChild(0);
    }
    
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

    public override void Input(PlayerStateManager stateMgr, InputEvent @event)
    {
        if(@event.IsActionPressed("Shoot"))
		{
            GD.Print("Shot fired");
            Shoot(stateMgr.GetNode("/root"));
        }
    }

    void Shoot(Node root) 
    {
        GD.Print(shootPoint);
        MissileProjectile proj = (MissileProjectile)Bullet.Instantiate();
        root.AddChild(proj);
        proj.Start(shootPoint.GlobalPosition, 0f, shootImpulse);

        GD.Print(proj.GlobalPosition);
    }
}