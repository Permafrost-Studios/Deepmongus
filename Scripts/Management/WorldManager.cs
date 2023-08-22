using Godot;
using System;

public partial class WorldManager : NodeSingleton<WorldManager> {

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
    public void ChangeLayerHandler(int newlevel) { 
        // each level should have a trigger box to signify their ID
        // TODO: Boxes made by the world maker thingy
        if (newlevel < m_status.playerCurrLayer) {
            GameManager.instance.PlayEndSceneHandler(GameManager.EndCause.WentUpLayer);
        }


    } 
    






    public struct GameStatus { // Should contain enough data that we can save and load the game
        // an instance of a ResourceInfo struct from Jaden
        public GameStatus() {}

        public int worldSeed = 0;
        public int playerCurrLayer = 0; // 0 Is waiting, 1 = they are in the game
        public double playerLayerTime = 0;
    }


    public GameStatus m_status = new GameStatus();
}
