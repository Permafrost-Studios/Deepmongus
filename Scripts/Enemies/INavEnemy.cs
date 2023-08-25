using Godot;
using System;
using System.Dynamic;
using System.Runtime.InteropServices;

public interface INavEnemy {
	/** 										INTERFACE PROPERTIES															**/
	public NavigationAgent2D? navAgt {get; set;}
	public float moveSpd {get; set;}
	public NavTargetType? navTgtTyp {get;}
	public System.Object? navTgt {get;}
	public bool isNavigating {get;}


	/** 										INTERFACE FUNCTIONS																**/
	public void StartNavigating(NavTargetType typ, System.Object uin);
	public void EndNavigating();



	/** 										INTERFACE 	TYPES																	**/
	public enum NavTargetType {
		kGlobalVec2,
		kNode2D
	}
}