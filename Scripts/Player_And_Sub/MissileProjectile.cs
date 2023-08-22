using Godot;
using System;

public partial class MissileProjectile : CharacterBody2D
{
    public override void _PhysicsProcess(double delta) 
	{
        this.MoveAndSlide();
        // this.MoveAndCollide(this.Velocity);
    }

    public void Start(Vector2 position, float direction, float speed)
    {
        this.Rotation = direction;
        this.GlobalPosition = position;
        this.Velocity = new Vector2(speed, 0).Rotated(this.Rotation);
    }
}