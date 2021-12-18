using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        
        // move in direction relative to the player
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
    }
}
