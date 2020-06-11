using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour, IClickable {

    public static event Action OnClicked = delegate { };
    bool isHovering;
    public bool IsHovering  { get { return isHovering; } set { isHovering = value; } }


   public void HandleClick()
    {
        OnClicked();
    }
}
