using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*Todo: Seperate nested raycasting into their own class
 * Separate Mouse click logic to seperate class  
 */
public class FollowMousePosition : MonoBehaviour
{
    Camera cam;
    public Camera RenderCam;
    Ray mouseRay, renderRay;
    public Texture2D mouseComputerTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private RaycastHit hit, renderHit;
    public LayerMask computerScreen;
    Vector3 CamPos;
    public EventSystem m_EventSystem;
    Vector3 textureToCam;
    public List<RaycastResult> list;
    IClickable buttonHit;

    void Start()
    {
        cam = Camera.main;
    }
    void FixedUpdate()
    {
        mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, mouseRay.direction * 100);
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, computerScreen))  //Should be in separate class - converts mouse position to ray.
        {
            //Set computer cursor to computer screen
            Cursor.visible = false;
            textureToCam = RenderCam.ViewportToWorldPoint(new Vector3(hit.textureCoord.x, hit.textureCoord.y, 10));
            transform.position = textureToCam;

            renderRay = new Ray(transform.position, transform.forward);
            Debug.DrawRay(renderRay.origin, renderRay.direction * 100);
            //Raycast from mouse pointer
            if (Physics.Raycast(renderRay, out renderHit, Mathf.Infinity))
            {
                buttonHit = renderHit.transform.GetComponent<IClickable>();
                if(buttonHit != null)
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
                if(buttonHit != null)
                {
                    buttonHit.IsHovering = false;
                }

            }

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
