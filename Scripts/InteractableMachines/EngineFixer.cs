using Godot;
using System;

public partial class EngineFixer : BaseMachine
{
    public override void Activate(int amount) 
    {
        if (!(SubResourceManager.instance.currentCharge > 10f)) 
        {
            return;
        }

        //Play animation OR Amongus minigame

        SubResourceManager.instance.AddCharge(amount);
    }
}