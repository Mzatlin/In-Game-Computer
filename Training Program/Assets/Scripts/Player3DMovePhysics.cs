﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player3DMovePhysics : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection, moveRotation;
    float camRotation;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetMovementDirection(Vector3 _moveDirection)
    {
        moveDirection = _moveDirection;
    }


    public void SetRotation(Vector3 _moveRotation)
    {
        moveRotation = _moveRotation;
    }

    public void SetCameraRotation(float _camRotation)
    {
        camRotation = _camRotation;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMoveDirection();
        ApplyMoveRotation();
    }

    void ApplyMoveDirection()
    {
        rb.velocity = moveDirection;
    }

    void ApplyMoveRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(moveRotation)); 
    }
}
