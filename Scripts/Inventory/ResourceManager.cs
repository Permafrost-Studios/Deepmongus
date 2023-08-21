using Godot;

public class ResourceManager : Node {

    int fuelCans;
    int torpedoes;
    int batteries;

    void UpdateResource(Node2D node) {

        switch( (node.GetParent() as Resource).type ) {

            case 0:

                if ( fuelCans < 2 ) {

                    fuelCans++;
                    node.QueueFree();

                }

                break;

            case 1:

                if ( torpedoes < 4 ) {

                    torpedoes++;
                    node.QueueFree();

                }

                break;

            case 2:

                if ( batteries < 2 ) {

                    batteries++;
                    node.QueueFree();

                }            

                break;

        }

    }

}