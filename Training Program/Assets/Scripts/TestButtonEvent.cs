using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonEvent : MonoBehaviour
{
    [SerializeField]
    StateMachineEvents InteractComputer;
    // Start is called before the first frame update
    void Start()
    {
        InteractComputer.OnInteractComputerEvent += HandleInteract;
    }

    private void HandleInteract()
    {
        Debug.Log("Testing123456");
    }


}
