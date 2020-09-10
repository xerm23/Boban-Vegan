using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(0, .4f)][SerializeField]
    private float smoothTime =5f;
    public Transform playerTransform;



    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float posX = Mathf.SmoothDamp(transform.position.x, playerTransform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, playerTransform.position.y+1.2f, ref velocity.y, smoothTime);

        transform.position = new Vector3(posX, posY, transform.position.z);

    }
}
