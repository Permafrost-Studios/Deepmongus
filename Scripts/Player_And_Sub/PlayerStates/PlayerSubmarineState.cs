using Godot;
using System;


public class PlayerSubmarineState : PlayerState 
{
    //Polish shooting behaviour
    //Add acceleration stuff

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
        stateMgr.cam.Zoom = new Vector2 (0.3f, 0.3f);

        stateMgr.currentCharacterBody = stateMgr;

        resourceManager = ResourceManager.instance;

        shootPoint = (Node2D)stateMgr.currentCharacterBody.GetNode("./Turret/ShootPoint");

        sonarArea = (Area2D)stateMgr.currentCharacterBody.GetNode("./Sonar");
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
        stateMgr.currentCharacterBody.Velocity = (new Vector2(stateMgr.horizontalInput, -stateMgr.verticalInput) * speed * speedMultiplier).LimitLength(speed * speedMultiplier);

		stateMgr.currentCharacterBody.MoveAndSlide();
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
            stateMgr.DepleteFuel(stateMgr.fuelDepletionRate * 2);

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
        // proj.Start(shootPoint.GlobalPosition, 0f, shootImpulse);
        proj.Start(shootPoint.GlobalPosition, 0f, (new Vector2(shootImpulse, 0).Rotated((shootPoint.GetParent() as Sprite2D).Rotation)));

        GD.Print(proj.GlobalPosition);
    }
}