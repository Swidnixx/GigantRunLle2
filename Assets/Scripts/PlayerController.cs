using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(IsGrounded())
            {
                rb.velocity = new Vector2(0f, jumpSpeed); 
            }
        }
        DrawRaycast();
    }
    private void DrawRaycast()
    {
        Debug.DrawLine(transform.position,
            transform.position + Vector3.down * 2);
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            Vector2.one, // do zmiany
            0,
            Vector3.down,
            0.6f, // do zmiany
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
