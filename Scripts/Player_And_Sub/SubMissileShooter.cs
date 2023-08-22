using Godot;
using System;

public partial class SubMissileShooter : Node
{
    PackedScene Bullet = (PackedScene)GD.Load("res://bullet.tscn");

    public override void _Input(InputEvent @event) 
    {
        if(Input.IsActionJustPressed("Shoot"))
		{
			Shoot();
		}
    }

    void Shoot() 
    {
        MissileProjectile proj = (MissileProjectile)Bullet.Instantiate();
        this.AddChild(proj);
    }
}