using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouseManager : MonoBehaviour
{
    [SerializeField]
    StateMachineEvents InteractComputer;
    [SerializeField]
    bool isActive = false;
    ITerminalCursorInteraction interaction;
    ISetTerminalCursor cursor;
    //This class will determine if the player is in the correct state
    //if they are in the correct state, it will call the necessary functions to setup the virtual pointer
    //it will also check if the player left the state and handle it appropriately
    // Start is called before the first frame update
    void Start()
    {
        cursor = GetComponent<ISetTerminalCursor>();
        interaction = GetComponent<ITerminalCursorInteraction>();
        InteractComputer.OnInteractComputerEvent += HandleEventEntry;
        InteractComputer.OnLeaveInteractComputerEvent += HandleEventLeave;
    }

    void OnDestroy()
    {
        InteractComputer.OnInteractComputerEvent -= HandleEventEntry;
        InteractComputer.OnLeaveInteractComputerEvent -= HandleEventLeave;
    }

    void HandleEventLeave()
    {
        isActive = false;
    }

    void HandleEventEntry()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            ProcessCursorFunctions();
        }

    }

    bool CanProcess()
    {
        //if in correct state, change pointer texter, check for clicks/hovers, etc. 
        return true;
    }
    void ProcessCursorFunctions()
    {
        if (CanProcess())
        {
            if (cursor != null)
            {
                cursor.SetCursorOnScreen();
            }
            if (interaction != null)
            {
                interaction.CheckMouseClick();
            }
        }
    }
}
