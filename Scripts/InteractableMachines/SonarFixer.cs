using Godot;
using System;

public partial class SonarFixer : BaseMachine
{
    public override void Activate(int amount) 
    {
        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddCharge(amount);
    }
}