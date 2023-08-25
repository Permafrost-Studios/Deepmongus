using Godot;
using System;

public partial class WorldGenerator : NodeSingleton<WorldGenerator>
{

    public override void _Ready() 
    {
        
    }

    public override void _PhysicsProcess(double delta) 
	{
        // this.MoveAndCollide(this.Velocity);
    }

    public void GenerateWorld(int layerCount, float amplitude) 
    {
        for (int x = 1; x < 100; x++) 
        {
            GD.Print("I am trahsh");
        }
    }
}