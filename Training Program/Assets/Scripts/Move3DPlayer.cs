using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3DPlayer : PlayerStateBase
{
    PlayerStateMachine player;
    public Move3DPlayer(PlayerStateMachine _player) : base(_player)
    {
        player = _player;
    }

    public override void Tick()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            player.SetState(new InteractComputer(player));
        }*/
    }

    public override void OnStateEnter()
    {
        player.GetComponent<Player3DInputController>().enabled = true;
        Debug.Log("You Just Entered State 1");
    }

    public override void OnStateExit()
    {
        player.GetComponent<Player3DInputController>().enabled = false;
        Debug.Log("Leaving State 1");
    }
}
