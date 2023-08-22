using Godot;
using System;

public partial class PlayerStateManager : CharacterBody2D
{
    public float horizontalInput;
    public float verticalInput;

    PlayerSubmarineState submState = new PlayerSubmarineState();
    PlayerBodyState bodyState = new PlayerBodyState();

    public PlayerState currentState;

    float fuelDepletionRate;

    public override void _Ready() 
    {
        currentState = submState;
    }

    public override void _Process(double delta) 
	{
        currentState.Update(this, delta);

        DepleteFuel(fuelDepletionRate);
    }

    public override void _PhysicsProcess(double delta) 
	{
        horizontalInput = Input.GetAxis("Left", "Right");
        verticalInput = Input.GetAxis("Down", "Up");

        currentState.PhysicsUpdate(this, delta);
    }

    public override void _Input(InputEvent @event) 
	{
        currentState.Input(this, @event.AsText());

        if(Input.IsActionJustPressed("Jump") && this.IsOnFloor())
		{

        }
    }

    public void SwitchState(PlayerState newState) 
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public void DepleteFuel(float depletionRate) 
    {
        //Call to the resource manager passing in the fuel depletion amount
    }
}