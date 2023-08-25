using Godot;
using System;

public partial class BatterySwapper : BaseMachine
{
    float chargePerBattery;

    public override void Activate(int amount) 
    {
        if (ResourceManager.instance.batteries >= amount) 
        {
            //Reduce batteries in ResourceManager
        }

        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddCharge(amount * chargePerBattery);
    }
}