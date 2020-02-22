using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private int moveX;
    private bool jumpInput;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private LayerMask raycastMask;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
    }
    
    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleInput()
    {
        moveX = 0;


        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }
    }
    
    private void HandleMovement()
    {
        var moveDir = new Vector2(moveX * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = (moveDir);
    }

    private void HandleJump()
    {
        if (jumpInput && CheckGrounding())
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        jumpInput = false;

    }

    private bool CheckGrounding()
    {
        Debug.DrawRay(leftFoot.position, Vector3.down * 0.5f, Color.red, 1f);
        Debug.DrawRay(rightFoot.position, Vector3.down * 0.5f, Color.red, 1f);
        
        if(Physics2D.Raycast(rightFoot.position, Vector2.down, 0.5f, raycastMask))
            if (Physics2D.Raycast(leftFoot.position, Vector2.down, 0.5f, raycastMask))
                return true;
        return false;
    }
}
