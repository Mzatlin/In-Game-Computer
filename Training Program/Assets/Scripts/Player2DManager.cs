using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DManager : MonoBehaviour, ICanMove
{
    [SerializeField]
    StateMachineEvents interactComputer;
    bool canMove;
    public bool CanMove{ get{ return canMove; } set{ canMove = value; ; }  }

    // Start is called before the first frame update
    void Start()
    {
        if(interactComputer != null)
        {
            interactComputer.OnInteractComputerEvent += HandleEnter;
            interactComputer.OnLeaveInteractComputerEvent += HandleLeave;
        }
    }
    void OnDestroy()
    {
        interactComputer.OnInteractComputerEvent -= HandleEnter;
        interactComputer.OnLeaveInteractComputerEvent -= HandleLeave;
    }

    private void HandleLeave()
    {
        canMove = false;
    }

    private void HandleEnter()
    {
        canMove = true;
    }

}
