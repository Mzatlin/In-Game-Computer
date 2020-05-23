using UnityEngine;

public class CameraRaycastToVirtualScreen : MonoBehaviour
{
    [SerializeField]
    private LayerMask screenLayer;

    private Camera mainCam;
    private Ray mouseRay;
    private RaycastHit screenHit;

    void Awake()
    {
        mainCam = GetComponent<Camera>();
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    void FixedUpdate()
    {
        mouseRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mainCam.transform.position, mouseRay.direction * 100);

        if (Physics.Raycast(mouseRay, out screenHit, Mathf.Infinity, screenLayer))
        {
     //       Cursor.visible = false;
        }
        else
        {
      //      Cursor.visible = true;
        }
    }

}
