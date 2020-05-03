using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToPoint : MonoBehaviour
{
    [SerializeField]
    private Transform fixationPoint;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private Transform monitor;
    [SerializeField]
    private Transform screen;

    private Camera mainCam;
    private bool isFixated = false;

    // Use this for initialization
    void Awake()
    {
        mainCam = GetComponent<Camera>();
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }

        monitor = fixationPoint.transform.parent;


    }

    // Update is called once per frame
    void Update()
    {

      /*  if (Input.GetKeyDown(KeyCode.E))
        {
            if(isFixated == false)
            {
                isFixated = true;
            }
            else
            {
                isFixated = false;
            }
        }

        if (isFixated)
        {
           mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, fixationPoint.position, moveSpeed * Time.deltaTime);
        
           // mainCam.transform.LookAt(monitor);
            var q = Quaternion.LookRotation(screen.position - mainCam.transform.position);
            mainCam.transform.rotation = Quaternion.RotateTowards(mainCam.transform.rotation, q, 90.0f * Time.deltaTime);
        */
     
    }
    public static void Test()
    {
        Debug.Log("Test Reached!");
    }

    public static void FixateToPoint(Transform start, Transform fixationPoint, float moveSpeed)
    {
        start.transform.position = Vector3.Lerp(start.transform.position, fixationPoint.position, moveSpeed * Time.deltaTime);

        // mainCam.transform.LookAt(monitor);
        var q = Quaternion.LookRotation(fixationPoint.position - fixationPoint.transform.position);
        start.transform.rotation = Quaternion.RotateTowards(start.transform.rotation, q, 90.0f * Time.deltaTime);
    }
}
