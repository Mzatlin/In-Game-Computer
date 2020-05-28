using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractComputer : PlayerStateBase{

    PlayerStateMachine player;
    public InteractComputer(PlayerStateMachine _player) : base(_player)
    {
        player = _player;
    }    

    public override void Tick()
    {
      //  if (Input.GetKeyDown(KeyCode.Escape))

        //player.GetFixationPoint() grabs the transform/position of the "fixation point" 
            //This is returned from a method that when the player is within a certai   n distance, is facing correctly,
            //And raycasting to an object that has an Iinteractable interface, will it try and retrieve its fixation point transform. 
        player.mainCam.FixateToPoint(player.mainCam.transform);
        ExitOnKeyPress();
    }

    public override void OnStateEnter()
    {
        Debug.Log("You just entered State 2");
    }

    public override void OnStateExit()
    {
        Debug.Log("Leaving State 2");
    }

    void ExitOnKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            player.GetComponent<PlayerInteract>().IsInteracting = false;
            player.SetState(new Move3DPlayer(player));
        }
    }
}
