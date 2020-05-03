using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector2 MovementFinal;
    Rigidbody2D rb;
    float speed = 5f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementFinal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        rb.velocity = MovementFinal * 5;
    }
}
