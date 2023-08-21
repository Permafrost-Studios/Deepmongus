using Godot;
using System;

public partial class SubManager : GenericSingleton<Node> 
{
    float maxFuel;
    float currentFuel;
    float fuelDrainRate; // In seconds

    float maxCharge; //Like electric charge which is recharged through batteries
    float currentCharge;

    int maxMissiles;
    int currentMissiles; //These are missiles that are LOADED and ready to fire - not spare supplies

    public override void _Process(double delta)
	{
        currentFuel -= fuelDrainRate * (float)delta;
	}

    public void AddFuel(float amt) 
    {
        currentFuel += amt;

        if (currentFuel <= 0)
        {
            Die();
        }
        
        currentFuel = Math.Clamp(currentCharge, -1, maxFuel);
    }

    public void AddCharge(float amt)
    {
        currentCharge += amt;

        if (currentCharge <= 0)
        {
            Die();
        }
        
        currentCharge = Math.Clamp(currentCharge, -1, maxCharge);
    }

    public void AddMissiles(int amt)
    {
        currentMissiles += amt;
        
        currentMissiles = Math.Clamp(currentMissiles, -1, maxMissiles);
    }

    void Die() 
    {
        //Transition to the "Game Over" scene / menu.
    }
}