using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseOnStart : MonoBehaviour
{
    CursorMode cursorMode = CursorMode.Auto;
    // Start is called before the first frame update
    void Awake()
    {
     //   Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Cursor.visible = false;
      //  Cursor.lockState = CursorLockMode.Locked;
    }
}
