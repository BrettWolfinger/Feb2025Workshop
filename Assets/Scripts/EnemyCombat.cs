using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    float timePassed = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.gameObject.tag == "Enemy" && other.gameObject.tag == "Player Attack")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > 5f)
        {
            Instantiate(projectilePrefab,transform.position, transform.rotation);
            timePassed = 0f;
        } 
    }
}
