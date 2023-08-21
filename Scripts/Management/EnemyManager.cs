using Godot;
using System;
using System.Runtime.InteropServices;

public partial class EnemyManager : GenericSingleton<Node> {
    public override void _EnterTree() {
        this.Name = "EnemyManager";
    }

    public override void _Ready() {

    }

    public override void _Process(double delta) {
        
    }


    /*-------------------------------------------------------------------------
                            SIGNAL HANDLERS
    -------------------------------------------------------------------------*/


    






    public struct GameStatus { // Should contain enough data that we can save and load the game
        // an instance of a ResourceInfo struct from Jaden
        public int worldSeed;
        public int playerCurrLayer;
        public double playerLayerTime;
    }


    public GameStatus m_status;
}
