using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed  = 2f;

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if((other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player Attack") ||
    //     (other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy Attack"))
    //     {
    //         Destroy(other.gameObject);
    //         Destroy(this.gameObject);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
    }

    //When projectile goes offscreen destroy it
    void OnBecameInvisible() 
    {
        Destroy(this.gameObject);
    }
}
