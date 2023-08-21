using Godot;

public partial class ResourceManager : GenericSingleton<Node> {

	int fuelCans;
	int torpedoes;
	int batteries;

	public void UpdateResource(Area2D node) {

		switch( (node as SubResource).type ) {

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
