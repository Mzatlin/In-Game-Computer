using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCursorFollow : MonoBehaviour, ISetTerminalCursor
{
    [SerializeField]
    Camera RenderCam;
    [SerializeField]
    LayerMask computerScreen;
    Camera cam;
    Ray mouseRay; 
    RaycastHit hit;
    CursorMode cursorMode = CursorMode.Auto;
    Vector3 textureToCam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorOnScreen();
    }

    public void SetCursorOnScreen()
    {
        mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, mouseRay.direction * 100);
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, computerScreen))  //Should be in separate class - converts mouse position to ray.
        {
            //Set computer cursor to computer screen
            Cursor.visible = false;
            textureToCam = RenderCam.ViewportToWorldPoint(new Vector3(hit.textureCoord.x, hit.textureCoord.y, 10));
            transform.position = textureToCam;

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
