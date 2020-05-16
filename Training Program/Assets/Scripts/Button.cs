using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour, IClickable {

    bool isHovering;
    public bool IsHovering  { get { return isHovering; } set { isHovering = value; } }

    void Update()
    {
        if (isHovering)
        {
      //      Debug.Log("Hovering");
        }
    }

   public void OnClick()
    {
        Debug.Log("Clicked");
    }

   public void HandleClick()
    {
        Debug.Log("I have been clicked!");
    }
}
