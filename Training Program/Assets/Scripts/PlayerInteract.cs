using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    PlayerStateMachine playerstate;
    private bool _isInteracting;
    Ray playerRay;
    RaycastHit hit;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    float distanceFromObject = 6f;
    public bool IsInteracting
    {
        get { return _isInteracting; } //add an interface
        set { _isInteracting = value; }
    }
    // Use this for initialization
    void Start()
    {
        playerstate = GetComponent<PlayerStateMachine>();
        //   playerstate.SetState(new InteractComputer(playerstate));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawInteractionRay();
    }

    void DrawInteractionRay()
    {
        playerRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(playerRay.origin, playerRay.direction * 100, Color.red);
        if (Physics.Raycast(playerRay, out hit, 10f, LayerMask.GetMask("Interactable")))
        {
            SetStateWithinDistance();
        }
    }

    void SetStateWithinDistance()
    {
        var dot = Vector3.Dot(transform.forward, hit.transform.forward);
        if (dot < 0 && Vector3.Distance(transform.position, hit.transform.position) < distanceFromObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerstate.SetState(new InteractComputer(playerstate));
            }
        }
        //throw an event that passes the transform of the fixation point, because all interactable object have fixationpoints 
        //Or maybe have it to where the camera fixates on an exact offset? 
    }

}
