using Godot;
using System;

public partial class ResourcePickup : Area2D {
	
	ResourceManager resourceManager;
	int i;
	
	public override void _Ready() {

		resourceManager = ResourceManager.instance;

	}

	public override void _Process(double delta) {

		for ( i = 0; i < this.GetOverlappingAreas().Count; i++ ) {

			resourceManager.UpdateResource( this.GetOverlappingAreas()[i] );

		}

	}

}
