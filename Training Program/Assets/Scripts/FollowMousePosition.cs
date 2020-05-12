using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


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
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    Vector3 textureToCam;
    public List<RaycastResult> list;

    void Start()
    {
        cam = Camera.main;
        m_Raycaster = GetComponent<GraphicRaycaster>();
    }
    void FixedUpdate()
    {
        mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, mouseRay.direction * 100);
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, computerScreen))
        {
            Cursor.visible = false;
            textureToCam = RenderCam.ViewportToWorldPoint(new Vector3(hit.textureCoord.x, hit.textureCoord.y, 10));
            transform.position = textureToCam;
            renderRay = new Ray(transform.position, transform.forward);
            Debug.DrawRay(renderRay.origin, renderRay.direction * 100);
            //Raycast from mouse pointer
            if (Physics.Raycast(renderRay, out renderHit, Mathf.Infinity))
            {
                //Right now only the mouse button down is recorded, mouse hover must also be taken into account. 
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Hit" + renderHit.transform.name);
                    var hit = renderHit.transform.GetComponent<IClickable>();
                    if (hit != null)
                    {
                        hit.HandleClick();
                    }
                    /*
                    m_PointerEventData = new PointerEventData(m_EventSystem);
                    m_PointerEventData.position = renderRay.origin;
                    list = new List<RaycastResult>();

                    m_Raycaster.Raycast(m_PointerEventData, list);

                    if (list != null && list.Count > 0)
                    {
                        Debug.Log("Hit: " + list[0].gameObject.name);
                    }
                    */
                }

            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
