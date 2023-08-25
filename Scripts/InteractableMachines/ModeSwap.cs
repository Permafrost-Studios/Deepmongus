using Godot;
using System;

public partial class ModeSwap : BaseMachine
{
    public override void Activate(int amount) 
    {
        GD.Print("Activating");

        PlayerStateManager stateMgr = (PlayerStateManager)GetNode("/root/JulianTesting/SubmarineBody");

        stateMgr.SwitchState(stateMgr.submState);
    }
}