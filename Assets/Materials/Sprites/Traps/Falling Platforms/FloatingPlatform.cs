using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("DestroySelf", .2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.ToString() == "8")
        {
            rb.AddForce(new Vector2(0, -120f));
            animator.SetBool("Hit", true);
        }
    }
    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
