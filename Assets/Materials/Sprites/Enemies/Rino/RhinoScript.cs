using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoScript : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    bool pom = true;

    // Update is called once per frame
    void Update()
    {
        float rhinoX = transform.position.x;
        float pX = player.transform.position.x;
        float rhinoY = transform.position.y;
        float pY = player.transform.position.y;
        if (rhinoX < pX + 10f && rhinoX > pX - 10f &&
            rhinoY < pY + .5f && rhinoY > pY - .5f && pom)
        {
            pom = false;
            Invoke("Sprint", 1.35f);
            animator.SetBool("Running", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.ToString() == "13")
        {
            pom = true;
            animator.SetBool("Hit", true);
            animator.SetBool("Running", false);
            Invoke("HitOff", .3f);
        }
    }

    private void Sprint()
    {
        rb.AddForce(new Vector2(450f * -transform.localScale.x,0f));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //mora da udari u nevidljivi objekat kako bi se zaustavio i okrenuo
        //nevidljivi objekat mora da bude pod layerom 13
        if (collision.gameObject.layer.ToString() == "13")
        {
            pom = true;
            animator.SetBool("Hit", true);
            animator.SetBool("Running", false);
            Invoke("HitOff", .3f);
        }
    }
    private void HitOff()
    {
        animator.SetBool("Hit", false);
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);

    }
}
