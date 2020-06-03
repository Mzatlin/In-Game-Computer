using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/StateMachine")]
public class StateMachineEvents : ScriptableObject
{
    public event Action OnInteractComputerEvent;
    public event Action OnLeaveInteractComputerEvent;

    public void EnterInteractComputer()
    {
        if(OnInteractComputerEvent != null)
        {
            OnInteractComputerEvent();
        }
    }
    public void LeaveInteractComputer()
    {
        if (OnLeaveInteractComputerEvent != null)
        {
            OnLeaveInteractComputerEvent();
        }
    }
}

