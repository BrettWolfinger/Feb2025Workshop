using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    float timePassed = 0f;
    public float enemyFireRate = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Attack") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }

    void Update()
    {
       timePassed += Time.deltaTime;
       if (timePassed > enemyFireRate)
       {
           Instantiate(projectilePrefab, transform.position, transform.rotation);
           timePassed = 0f;
       }
    }
}
