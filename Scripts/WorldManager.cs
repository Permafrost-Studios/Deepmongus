using Godot;
using System;
using System.Runtime.InteropServices;

public partial class WorldManager : GenericSingleton<Node> {
    public override void _EnterTree() {
        base._EnterTree();
    }

    public override void _Ready() {

    }

    public override void _Process(double delta) {
        
    }

    public struct GameStatus { // Should contain enough data that we can save and load the game
        // an instance of a ResourceInfo struct from Jaden
        public int worldSeed;
        public int a;
    }


    public GameStatus m_status;
}
