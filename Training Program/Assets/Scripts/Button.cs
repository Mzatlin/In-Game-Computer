using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour, IClickable {

    bool isHovering;
    public bool IsHovering  { get { return isHovering; } set { isHovering = value; } }


   public void HandleClick()
    {
        Debug.Log("I have been clicked!");
    }
}
