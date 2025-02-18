using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject sword;
    public GameObject shield;

    private bool IsSlashing = false;
    private bool IsDeflecting = false;
    private CapsuleCollider2D swordCollider;


    public void OnFire()
    {
        //TODO: Implement player firing projectile 
    }

    //TODO: Implement OnSlash() event using Swing() coroutine

    public void OnDeflect()
    {
        //Note, this is spammable right now
        StartCoroutine(Deflect());
    }

    private IEnumerator Swing(float time)
    {
        float elapsedTime = 0.0f;
        swordCollider.enabled = true;
        Quaternion startingRotation = Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, 0.0f ) );
        Quaternion targetRotation =  Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, 100f ) );
        while (elapsedTime < time) {
            print(elapsedTime);
            elapsedTime += Time.deltaTime;
            // Rotations
            sword.transform.localRotation = Quaternion.Lerp(startingRotation, targetRotation,  elapsedTime / time  );
            yield return new WaitForEndOfFrame();
        }
        //reset everything back for next time
        sword.transform.localRotation = startingRotation;
        IsSlashing = false;
        swordCollider.enabled = false;
    }

    private IEnumerator Deflect()
    {
        //TODO: Implement the Deflect function
        yield break; //Remove this, was here to prevent errors
    }

    public void Awake()
    {
        swordCollider = GetComponentInChildren<CapsuleCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.gameObject.tag == "Player" && other.gameObject.tag == "Enemy Attack")
        {
            if (IsDeflecting)
            {
                other.gameObject.transform.Rotate(0f, 0, 180.0f);
                other.gameObject.tag = "Player Attack"; //flip the tag so it can damage enemies
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
