using Godot;
using System;

public class PlayerSubmarineState : PlayerState 
{
    //Add shooting behaviour
    //Add superSpeed behaviour

    float speed = 300f;
    float speedMultiplier = 1f;
    float shootImpulse = 1200f;

    float fuelDepletionRate;

    Area2D sonarArea;
    ResourceManager resourceManager;

    Node2D shootPoint; // Use get child or something
    PackedScene Bullet = (PackedScene)GD.Load("res://Prefabs/missile.tscn");

    public override void Enter(PlayerStateManager stateMgr) 
    {
        resourceManager = ResourceManager.instance;

        shootPoint = (Node2D)stateMgr.GetChild(0);

        sonarArea = (Area2D)stateMgr.GetChild(3);
    }
    
    public override void Update(PlayerStateManager stateMgr, double delta)
    {
        if (sonarArea.GetOverlappingBodies().Count > 0 || sonarArea.GetOverlappingAreas().Count > 0) 
        {
            for (int i = 0; i < sonarArea.GetOverlappingBodies().Count; i++ ) 
            {
                // Display warning message
            }

            for (int j = 0; j < sonarArea.GetOverlappingAreas().Count; j++ ) 
            {
                // Display warning message
            }
        }

        stateMgr.DepleteFuel(fuelDepletionRate); //Depletes fuel ON TOP of what is depleted in the state manager
    }

    public override void PhysicsUpdate(PlayerStateManager stateMgr, double delta)
    {
        stateMgr.Velocity = (new Vector2(stateMgr.horizontalInput, -stateMgr.verticalInput) * speed * speedMultiplier).LimitLength(speed * speedMultiplier);

		stateMgr.MoveAndSlide();
    }

    public override void Exit(PlayerStateManager stateMgr) {}

    public override void Input(PlayerStateManager stateMgr, InputEvent @event)
    {
        if(@event.IsActionPressed("Shoot"))
		{
            GD.Print("Shot fired");
            Shoot(stateMgr.GetNode("/root"));
        }

        if(@event.IsAction("Jump")) //Depletes double fuel if the ship is going fast
        {
            stateMgr.DepleteFuel(stateMgr.fuelDepletionRate);

            speedMultiplier = 2f;
        }

        if(@event.IsActionReleased("Jump")) 
        {
            speedMultiplier = 1f;
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