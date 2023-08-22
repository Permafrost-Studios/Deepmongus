using Godot;
using System;

public abstract class PlayerState
{
    public abstract void Enter(PlayerStateManager stateMgr);
    
    public abstract void Update(PlayerStateManager stateMgr, double delta);

    public abstract void PhysicsUpdate(PlayerStateManager stateMgr, double delta);

    public abstract void Exit(PlayerStateManager stateMgr);

    public abstract void Input(PlayerStateManager stateMgr, InputEvent @event);
}