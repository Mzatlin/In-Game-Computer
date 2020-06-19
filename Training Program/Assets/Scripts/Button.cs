using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour, IClickable, IButton{
     
    public event Action OnClicked = delegate { };
    bool isHovering;
    public bool IsHovering  { get { return isHovering; } set { isHovering = value; } }


   public void HandleClick()
    {
        OnClicked();
        gameObject.SetActive(false);
    }
}
