using Godot;
using System;

public partial class MissileProjectile : CharacterBody2D
{
    public void Start(Vector2 position, float direction, float speed)
    {
        this.Rotation = direction;
        this.Position = position;
        this.Velocity = new Vector2(speed, 0).Rotated(this.Rotation);
    }
}