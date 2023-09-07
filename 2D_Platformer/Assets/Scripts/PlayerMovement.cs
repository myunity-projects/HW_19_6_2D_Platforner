using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]    
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    [Header("Settings")]
    [SerializeField] private float jumpOffset;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D _rigidbody2D;

    private CapsuleCollider2D _collider2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        GlobalVariables.isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    private void FlipSprite()
    {       
        if(GlobalVariables.playerHasHorizontalMovement)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);
        }        
    }

    private void Run()
    {
        GlobalVariables.playerHasHorizontalMovement = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        Vector2 playerVelocity = new Vector2(GlobalVariables.moveInput.x * runSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = playerVelocity;
    }

    public void Jump()
    {        
        if (GlobalVariables.isGrounded)
        {
            _rigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
