using Godot;
using System;

public partial class AaviTesting : Node
{
	// Called when the node enters the scene tree for the first time.
	WorldManager? worldmgr;
	public override void _Ready()	{
		worldmgr = (WorldManager) WorldManager.instance;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
