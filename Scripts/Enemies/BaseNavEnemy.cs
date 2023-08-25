using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class BaseNavEnemy : CharacterBody2D, INavEnemy {
	[Export] public NavigationAgent2D? navAgt {get; set;}
	[Export] public float moveSpd {get; set;} = 500f;
	public INavEnemy.NavTargetType? navTgtTyp {get; set;} = new INavEnemy.NavTargetType();
	public INavEnemy.NavTargetUnion? navTgt {get; private set;} = new INavEnemy.NavTargetUnion();
  [Export] public bool isNavigating {get; private set;} = false;

	void INavEnemy.StartNavigating(INavEnemy.NavTargetType typ, INavEnemy.NavTargetUnion uin) {
		isNavigating = true;
		navTgtTyp = typ;
		switch (typ) {
			case INavEnemy.NavTargetType.followNd:
				navTgt = navTgt!.Value with { followNd = uin.followNd };
				break;
			case INavEnemy.NavTargetType.followGPos:
				navTgt = navTgt!.Value with { followGPos = uin.followGPos };
				break;
		}
  }

  void INavEnemy.EndNavigating() {
		isNavigating = false;
		this.Velocity = new(0,0);
  }


  public override void _Ready() {
		navAgt!.VelocityComputed += FollowWVel;
		// nav!.TargetPosition = pos;
		// nav.TargetDesiredDistance = 1f; // when it is considered close enough
		// nav.PathDesiredDistance = 10f; // step size
		// nav.AvoidanceEnabled = true;
		// nav.MaxSpeed = moveSpd;
	}


	public void FollowWVel(Godot.Vector2 velocity) {
		//this.ChangeTarget(this.GetNode<CharacterBody2D>("../CharacterBody2D").GlobalPosition); // necessary to recompute path if obstacles encountered
		UpdatePath();

		// navAgt!.TargetPosition = navTgt.Value
		this.Velocity = velocity;
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta) {
			if (isNavigating && navAgt != null) {
				Vector2 reqvel = (navAgt!.GetNextPathPosition() - this.GlobalPosition).Normalized() * moveSpd;
				navAgt!.Velocity = (Vector2) reqvel;
			}

			this.MoveAndSlide();
    }
    public async void UpdatePath() {
			await Task.Delay(500);
			GD.Print("printin");
			Vector2 _newpos;
			switch (navTgtTyp) {
				case INavEnemy.NavTargetType.followNd:
					_newpos = navTgt!.Value.followNd.GlobalPosition;
					break;
				case INavEnemy.NavTargetType.followGPos:
					_newpos = navTgt!.Value.followGPos;
					break;
				default:
					_newpos = this.GlobalPosition;
					break;
			}

			navAgt!.TargetPosition = _newpos;
	}
}
