using Godot;

public partial class ResourcePickup : Area2D {
	
	ResourceManager resourceManager;
	int i;
	
	public override void _Process(double delta) {

		for ( i = 0; i < this.GetOverlappingAreas().Count; i++ ) {

			resourceManager = (ResourceManager)ResourceManager.instance;
			resourceManager.UpdateResource( this.GetOverlappingAreas()[i] );

		}

	}

}
