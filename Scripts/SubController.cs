using Godot;
using System;

public partial class SubController : CharacterBody2D
{
    [Export] float speed = 100f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float horizontalInput = Input.GetAxis("Left", "Right");
		float verticalInput = Input.GetAxis("Down", "Up");

		this.Velocity = (new Vector2(horizontalInput, -verticalInput) * speed).LimitLength(speed);

		this.MoveAndSlide();
	}
}