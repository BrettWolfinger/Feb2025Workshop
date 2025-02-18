using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed  = 2f;

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
