using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 12);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DeathPart>() == null)
            Destroy(this.gameObject);

    }

}
