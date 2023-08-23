using Godot;
using System;

public partial class EngineFixer : BaseMachine
{
    public override void Activate(int amount) 
    {
        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddCharge(amount);
    }
}