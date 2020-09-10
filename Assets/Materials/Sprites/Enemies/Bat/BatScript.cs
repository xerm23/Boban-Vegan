using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Transform playerTransform;
    private Vector3 startPosition;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        if (playerTransform.position.x > startPosition.x - 3 &&  playerTransform.position.x < startPosition.x + 3 
            && playerTransform.position.y < startPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);

            if (transform.position.x < playerTransform.position.x) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);


            animator.SetBool("Flying", true);
        }
        else if(startPosition.x == transform.position.x)
        {
            animator.SetBool("Flying", false);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            if (transform.position.x < startPosition.x) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
