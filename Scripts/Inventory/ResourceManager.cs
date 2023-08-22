using Godot;
using System;

public partial class ResourceManager : NodeSingleton<ResourceManager> {

	int fuelCans;
	int torpedoes;
	int batteries;

	public void UpdateResource(Area2D node) {

		GD.Print(fuelCans);
		GD.Print(torpedoes);
		GD.Print(batteries);

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

		GD.Print(fuelCans);
		GD.Print(torpedoes);
		GD.Print(batteries);

	}

}
