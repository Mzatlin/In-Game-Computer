using UnityEngine;
[RequireComponent(typeof(Player3DMovePhysics))]
public class Player3DInputController : MonoBehaviour
{
    Player3DMovePhysics movePhysics;
    Vector3 moveDirection, lookRotation, movehorizontal, movevertical;
    public Camera cam;
    float RotY, RotX, moveX, moveY;
    [SerializeField]
    float movespeed = 10;
    float looksensitivity = 10, cameraRotation;
    private float currentCameraRotationX = 0;
    private float cameraRotationLimit = 85f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movePhysics = GetComponent<Player3DMovePhysics>();
    }

    // Update is called once per frame
    //Move physics to the 
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        movehorizontal = transform.right * moveX;
        movevertical = transform.forward * moveY;
        moveDirection = (movehorizontal + movevertical);
        //rb.velocity = moveDirection * movespeed; //physics method 
        movePhysics.SetMovementDirection(moveDirection * movespeed);

        RotY = Input.GetAxisRaw("Mouse X");
        RotX = Input.GetAxisRaw("Mouse Y");

        lookRotation = new Vector3(0, RotY, 0) * looksensitivity;
        cameraRotation = RotX * looksensitivity;


        // rb.MoveRotation(rb.rotation * Quaternion.Euler(lookRotation)); //physics method
        movePhysics.SetRotation(lookRotation);
        if (cam != null)
        {

            //Set rotation and clamp it
            currentCameraRotationX -= cameraRotation;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            //apply rotation to camera 
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //physics method
        }
    }
}
