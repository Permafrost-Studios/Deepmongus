using Godot;
using System;

public partial class FuelPumper : BaseMachine
{
    float fuelPerCan;

    public override void Activate(int amount) 
    {
        if (!(SubResourceManager.instance.currentCharge > 10f)) 
        {
            return;
        }

        //Play animation OR Amongus minigame
        //

        SubResourceManager.instance.AddFuel(amount * fuelPerCan);
    }
}