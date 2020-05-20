using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCursorInteractions : MonoBehaviour, ITerminalCursorInteraction
{
    Camera cam;
    Ray renderRay;
    private RaycastHit renderHit;
    IClickable buttonHit;


    void Start()
    {
        cam = Camera.main;
    }

    public void CheckMouseClick()
    {
        renderRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(renderRay.origin, renderRay.direction * 100);
        //Raycast from mouse pointer
        if (Physics.Raycast(renderRay, out renderHit, Mathf.Infinity))
        {
            buttonHit = renderHit.transform.GetComponent<IClickable>();
            if (buttonHit != null)
            {
                buttonHit.IsHovering = true;
            }

            //Right now only the mouse button down is recorded, mouse hover must also be taken into account. 
            if (Input.GetMouseButtonDown(0))
            {

                if (buttonHit != null)
                {
                    buttonHit.HandleClick();
                }
            }

        }
        else
        {
            if (buttonHit != null)
            {
                buttonHit.IsHovering = false;
            }

        }
    }
}
