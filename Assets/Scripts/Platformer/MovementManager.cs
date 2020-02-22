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

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
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

    private void FixedUpdate()
    {
        var moveDir = new Vector2(moveX * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = (moveDir);
        

        if (jumpInput)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpInput = false;
        }
    }
}
