using Godot;
using System;

public partial class BatterySwapper : BaseMachine
{
    float chargePerBattery;

    public override void Activate(int amount) 
    {
        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddCharge(amount * chargePerBattery);
    }
}