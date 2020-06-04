using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

    private PlayerStateBase currentState;
    public List<StateMachineEvents> stateEvents = new List<StateMachineEvents>();
    public Camera mainCam;

    void Awake()
    {
        mainCam = GetComponent<Camera>();
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    void Start () {
        SetState(new Move3DPlayer(this));
	}
	
	// Update is called once per frame
	void Update () {
        currentState.Tick();
	}

    public void SetState(PlayerStateBase _state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = _state;

        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
