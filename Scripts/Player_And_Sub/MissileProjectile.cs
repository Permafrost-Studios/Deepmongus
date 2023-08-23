using Godot;
using System;

public partial class MissileProjectile : RigidBody2D
{
    public override void _PhysicsProcess(double delta) 
	{
        // this.MoveAndCollide(this.Velocity);
    }

    public void Start(Vector2 position, float direction, float impulse)
    {
        this.Rotation = direction;
        this.GlobalPosition = position;
        this.ApplyCentralImpulse(new Vector2(impulse, 0).Rotated(this.Rotation));
    }
}