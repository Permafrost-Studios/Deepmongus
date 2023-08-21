using Godot;
using System;
using System.Runtime.InteropServices;

public partial class WorldManager : GenericSingleton<WorldManager> {

    public override void _EnterTree() {
        this.Name = "WorldManager";
    }

    public override void _Ready() {

    }

    public override void _Process(double delta) {
        DoLevelCalculations(delta);
    }


    private void DoLevelCalculations(double delta) {
        
    }

    public void PrintThing() {
        GD.Print("print success");
    }


    /*-------------------------------------------------------------------------
                            SIGNAL HANDLERS
    -------------------------------------------------------------------------*/
    public void ChangeLevelHandler() {
    } // each level should have a trigger box to signify their ID

    






    public struct GameStatus { // Should contain enough data that we can save and load the game
        // an instance of a ResourceInfo struct from Jaden
        public int worldSeed;
        public int playerCurrLayer;
        public double playerLayerTime;
    }


    public GameStatus m_status;
}
