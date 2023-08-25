using Godot;
using System;
using System.Dynamic;
using System.Runtime.InteropServices;

public interface INavEnemy {
	/** 										INTERFACE PROPERTIES															**/
	public NavigationAgent2D? navAgt {get; set;}
	public float moveSpd {get; set;}
	public NavTargetType? navTgtTyp {get;}
	public NavTargetUnion? navTgt {get;}
	public bool isNavigating {get;}


	/** 										INTERFACE FUNCTIONS																**/
	public void StartNavigating(NavTargetType typ, NavTargetUnion uin);
	public void EndNavigating();



	/** 										INTERFACE 	TYPES																	**/
	public enum NavTargetType {
		followGPos,
		followNd
	}
	[StructLayout(LayoutKind.Explicit)]
	struct NavTargetUnion{
    [FieldOffset(0)]
    public Vector2 followGPos;
    [FieldOffset(0)]
    public Node2D followNd;
	}
}