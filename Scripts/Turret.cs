using Godot;
using System;
using System.Diagnostics;

public partial class Turret : Sprite2D
{
    public override void _Process(double delta) 
    {
        LookAt(GetGlobalMousePosition());
    }
}