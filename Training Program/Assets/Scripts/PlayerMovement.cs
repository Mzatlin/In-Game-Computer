using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    ICanMove movement;
    Vector2 MovementFinal;
    Rigidbody2D rb;
    float speed = 5f;
    // Use this for initialization
    void Start()
    {
        movement = GetComponent<ICanMove>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movement != null && movement.CanMove)
        {
            MovementFinal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            rb.velocity = MovementFinal * 5;
        }
    }
}
