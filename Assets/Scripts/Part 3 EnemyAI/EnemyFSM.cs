using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {Scanning, AttackPlayer}

    public EnemyState currentState = EnemyState.Scanning;

    public int rotationSpeed = 20;
    private int rotationDirection = 1;

    public EnemyAISight sightSensor;
    public EnemyCombat enemyCombat;

    // Update is called once per frame
    void Update()
    {
        //TODO: Call the appropriate state action depending on the currentState
        if (currentState == EnemyState.Scanning) {
            Scanning();
        } else if (currentState == EnemyState.AttackPlayer) {
            AttackPlayer();
        }
    }

    //turret passively rotating
    void Scanning()
    {
        if (sightSensor.detectedObject != null) {
            currentState = EnemyState.AttackPlayer;
        }
        
        if(transform.rotation.eulerAngles.z >= 270)
        {
            rotationDirection = -1;
            
        }
        if(transform.rotation.eulerAngles.z <= 90)
        {
            rotationDirection = 1;
        }

        transform.Rotate(0,0,rotationDirection* rotationSpeed*Time.deltaTime);

    }

    //turret attacking player
    void AttackPlayer()
    {
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.Scanning;
        }

        //turn to attack the player
        Vector3 directionToController = 
            Vector3.Normalize(sightSensor.detectedObject.bounds.center - transform.position);

        float angleToCollider = Mathf.Atan2(directionToController.y, directionToController.x) * Mathf.Rad2Deg - 90; //offset by 90 to align with y

        transform.rotation = Quaternion.Euler(0, 0, angleToCollider);

        //TODO: Implement enemy firing.
        //Use the reference to the enemy combat script. We will have to refactor that script
        //It will help to use a coroutine!
        if (!enemyCombat.isOnCooldown) {
            StartCoroutine(enemyCombat.Fire());
        }
        
    }
}
