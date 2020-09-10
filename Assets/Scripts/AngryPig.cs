using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPig : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    private Animator animator;
    public float moveSpeed = -2f;

    SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.ToString() == "13")
        moveSpeed *= -1;
        Flip();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = new Vector2(moveSpeed, rigidBody2D.velocity.y);
        rigidBody2D.velocity = targetVelocity;
    }
    private void FixedUpdate()
    {

    //    animator.SetFloat("Speed", Math.Abs(moveSpeed));
    }

    private void Flip()
    {
        spriteRend.flipX = !spriteRend.flipX;
    }
}
