using Godot;
using System;

public abstract partial class BaseMachine : Area2D
{
    public abstract void Activate(int amount);
}