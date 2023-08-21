using Godot;
using System;

/// <summary>
/// static instance lazyloaded, generic arg must be a type of node as it just makes a node /root/NameOfYourDerivedType
/// </summary>
public abstract partial class GenericSingleton<T> : Node where T: Node, new() {
	private static readonly Lazy<T> lazyInstance = new Lazy<T>(CreateObject, System.Threading.LazyThreadSafetyMode.PublicationOnly);
	public static T instance => lazyInstance.Value;

	private static T CreateObject() {
		var thisobj = new T();
		((SceneTree) Engine.GetMainLoop()).Root.AddChild(thisobj);
    return thisobj;
	}
}