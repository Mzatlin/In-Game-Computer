using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase
{
    protected PlayerStateMachine player;
    public abstract void Tick();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public PlayerStateBase(PlayerStateMachine _player)
    {
        this.player = _player;
    }

}
