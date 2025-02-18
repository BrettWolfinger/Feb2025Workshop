using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    float timePassed = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: Implement behavior for enemy destruction on projectile collision
    }

    //void Update()
    //{
    //    timePassed += Time.deltaTime;
    //    if (timePassed > 5f)
    //    {
    //        Instantiate(projectilePrefab, transform.position, transform.rotation);
    //        timePassed = 0f;
    //    }
    //}
}
