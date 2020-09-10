using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{

    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public void Move()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else if (waypointIndex == waypoints.Length) waypointIndex = 0;

    }
}
