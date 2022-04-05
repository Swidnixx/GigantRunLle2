using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 10;
    public float liftingForce = 100;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool doubleJumped;

    void OnValidate()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
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
                doubleJumped = false;
            }
            else if(!doubleJumped)
            {
                rb.velocity = new Vector2(0f, jumpSpeed);
                doubleJumped = true;
            }
        }

        if(Input.GetMouseButton(0))
        {
            if (rb.velocity.y <= 0)
            {
                rb.AddForce(new Vector2(0, liftingForce) * Time.deltaTime); 
            }
        }
        DrawRaycast();
    }
    private void DrawRaycast()
    {
        Debug.DrawLine(transform.position,
            transform.position + Vector3.down * 1.1f);
    }
    private void OnDrawGizmos()
    {
        Vector3 playerPos = transform.position;
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(playerPos, boxCollider.bounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerPos + Vector3.down * 0.1f,
           boxCollider.bounds.size);
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.bounds.size, 
            0,
            Vector3.down,
            0.1f, 
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
