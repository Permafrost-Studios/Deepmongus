using Godot;
using System;

/// <summary>
/// static instance lazyloaded, generic arg must be a type of node as it just makes a node /root/NameOfYourDerivedType
/// Inheritance looks like Yourtype <- GenericSingleton<YourType> <- Godot.Node 
/// </summary>
public abstract partial class NodeSingleton<T> : Node where T: Node, new() {
	private static readonly Lazy<T> lazyInstance = new Lazy<T>(CreateObject, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
	public static T instance => lazyInstance.Value;

	private static T CreateObject() {
		T thisobj = new T();
		((SceneTree) Engine.GetMainLoop()).Root.CallDeferred(Node.MethodName.AddChild, thisobj);
    return thisobj;
	}
}