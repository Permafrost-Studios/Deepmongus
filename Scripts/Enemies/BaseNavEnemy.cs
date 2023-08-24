using Godot;
using System;

public partial class BaseNavEnemy : CharacterBody2D {
	[Export]
	private NavigationAgent2D? nav;
	[Export]
	private float moveSpd = 500.0f;
  private Vector2 moveTgt = new(1000f, 100f);

	private Vector2 currTgtPos;


	public override void _Ready() {
		nav!.VelocityComputed += FollowWVel;
	}


	public void FollowWVel(Godot.Vector2 velocity) {
		GD.Print("new vel" + velocity.ToString());
		this.ChangeTarget(this.GetNode<CharacterBody2D>("../CharacterBody2D").GlobalPosition); // necessary to recompute path if obstacles encountered
		this.Velocity = velocity;
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta) {
			var reqvel = (nav!.GetNextPathPosition() - this.GlobalPosition).Normalized() * moveSpd;
			nav!.Velocity = reqvel;
			this.MoveAndSlide();
    }
    public void ChangeTarget(Vector2 pos) {
		nav!.TargetPosition = pos;
		nav.TargetDesiredDistance = 1f; // when it is considered close enough
		nav.PathDesiredDistance = 10f; // step size
		nav.AvoidanceEnabled = true;
		nav.MaxSpeed = moveSpd;
	}
}
