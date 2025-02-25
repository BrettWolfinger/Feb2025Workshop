using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /*
    * Demonstration of C# events. Don't worry too much about these!
    */

    public static Action PlayerDestroyed = delegate { };
    public static Action EnemyDestroyed = delegate { };

    void OnDestroy()
    {
        if(gameObject.tag == "Player")
        {
            PlayerDestroyed.Invoke();
        }
        else{
            EnemyDestroyed.Invoke();
        }
    }
}
