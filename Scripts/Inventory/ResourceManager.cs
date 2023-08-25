using Godot;
using System;

public partial class ResourceManager : NodeSingleton<ResourceManager> {

	public int fuelCans;
	public int torpedoes;
	public int batteries;

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
