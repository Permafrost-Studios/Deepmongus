using Godot;
using System;

public partial class MissileLoader : BaseMachine
{
    public override void Activate(int amount) 
    {
        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddMissiles(amount);
    }
}