using Godot;

public class Resource : Node {

    public enum resourceType {

        fuelCan,
        torpedo,
        battery

    }

    [Export] public int type;

} // LOOOOOOOOOOOL I FORGOT HOW TO DO IT