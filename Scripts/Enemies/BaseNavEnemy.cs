using Godot;
using System;
using System.Threading.Tasks;

public partial class BaseNavEnemy : CharacterBody2D, INavEnemy {
	NavigationAgent2D? _navAgt;
	[Export] public NavigationAgent2D? navAgt {get; set;}
	[Export] public float moveSpd {get; set;} = 500f;
	public INavEnemy.NavTargetType? navTgtTyp {get; set;} = new INavEnemy.NavTargetType();
	public System.Object? navTgt {get; private set;}
  [Export] public bool isNavigating {get; private set;} = false;

	void INavEnemy.StartNavigating(INavEnemy.NavTargetType typ, System.Object tgt) {
		isNavigating = true;
		navTgtTyp = typ;
		navTgt = tgt;
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
				case INavEnemy.NavTargetType.kNode2D:
					_newpos = (navTgt as Node2D)!.GlobalPosition;
					break;
				case INavEnemy.NavTargetType.kGlobalVec2:
					_newpos = (navTgt as Godot.Vector2?)!.Value;
					break;
				default:
					_newpos = this.GlobalPosition;
					break;
			}

			navAgt!.TargetPosition = _newpos;
	}
}
