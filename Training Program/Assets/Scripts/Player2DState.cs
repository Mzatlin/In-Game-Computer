using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DState : PlayerStateBase
{
    PlayerStateMachine player;
    public Player2DState(PlayerStateMachine _player) : base(_player)
    {
        player = _player;
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        player.GetComponent<Player3DInputController>().enabled = true;
        Debug.Log("You Just Entered State 3");
    }

    public override void OnStateExit()
    {
        player.GetComponent<Player3DInputController>().enabled = false;
        Debug.Log("Leaving State 3");
    }
}
