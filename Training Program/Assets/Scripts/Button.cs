using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour, IClickable {

   public void OnClick()
    {
        Debug.Log("Clicked");
    }

   public void HandleClick()
    {
        Debug.Log("I have been clicked!");
    }
}
