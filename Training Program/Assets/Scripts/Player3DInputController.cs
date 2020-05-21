using UnityEngine;

[RequireComponent(typeof(Player3DMovePhysics))]
public class Player3DInputController : MonoBehaviour
{
    [SerializeField]
    float movespeed = 10;

    Player3DMovePhysics movePhysics;
    Vector3 moveDirection, lookRotation, movehorizontal, movevertical;
    Camera cam;
    float RotY, RotX, moveX, moveY;
    float looksensitivity = 10, cameraRotation;
    float currentCameraRotationX = 0;
    float cameraRotationLimit = 85f;

    void Start()
    {
        movePhysics = GetComponent<Player3DMovePhysics>();
        cam = Camera.main;
    }

    void Update()
    {
        InputMovement();
        InputRotation();
    }

    void InputMovement()
    {
        //Set Horizontal and Vertical movement based on WASD input
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        movehorizontal = transform.right * moveX;
        movevertical = transform.forward * moveY;

        //Apply Movement
        moveDirection = (movehorizontal + movevertical);
        movePhysics.SetMovementDirection(moveDirection * movespeed);
    }

    void InputRotation()
    {
        //Set rotation based on x and y mouse movement
        RotY = Input.GetAxisRaw("Mouse X");
        RotX = Input.GetAxisRaw("Mouse Y");

        lookRotation = new Vector3(0, RotY, 0) * looksensitivity;
      
        //Apply rotation
        movePhysics.SetRotation(lookRotation);

        //Set and apply camera rotation
        cameraRotation = RotX * looksensitivity;
        InputCameraRotation(cameraRotation);
    }

    void InputCameraRotation(float _camRotation)
    {
        if (cam != null)
        {
            //Invert and restrict camera movement along x-axis
            currentCameraRotationX -= cameraRotation;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            //Apply rotation to camera 
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); 
        }
    }
}
