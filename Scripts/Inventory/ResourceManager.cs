using Godot;

public class ResourceManager : Node {

    int fuelCans;
    int torpedoes;
    int batteries;

    void UpdateResource(Node2D node) {

        Switch((node.GetParent() as Resource).type) {

            case 0:

                if ( fuelCans < 2 ) {

                    fuelCans++;
                    node.queue_free();

                }

                break;

            case 1:

                if ( torpedoes < 4 ) {

                    torpedoes++;
                    node.queue_free();

                }

                break;

            case 2:

                if ( batteries < 2 ) {

                    batteries++;
                    node.queue_free();

                }            

                break;

        }

    }

}