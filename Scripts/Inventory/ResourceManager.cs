using Godot;
using System;

public partial class ResourceManager : NodeSingleton<ResourceManager> {

	int fuelCans;
	int torpedoes;
	int batteries;

	public void UpdateResource(Area2D node) {

		switch( (node as SubResource).type ) {

			case 0:

				if ( fuelCans < 2 ) { fuelCans++; }
				break;

			case 1:

				if ( torpedoes < 4 ) { torpedoes++; }
				break;

			case 2:

				if ( batteries < 2 ) { batteries++; }            
				break;

		}

		node.QueueFree();

	}

}
