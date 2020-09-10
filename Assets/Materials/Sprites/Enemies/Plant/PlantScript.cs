using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{


    Animator animator;

    public GameObject bulletPrefab;
    public GameObject bulletHolder;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, bulletHolder.transform.position, bulletHolder.transform.rotation);
        bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4f*this.gameObject.transform.localScale.x, 0f), ForceMode2D.Impulse);
    }




}
