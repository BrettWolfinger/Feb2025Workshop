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
    private float deflectTime = 0.5f;
    
    public int damageToTake = 1; // 👈 LOOK HERE 👈
    private PlayerHealth playerHealth; // 👈 LOOK HERE 👈

    void Awake() {
        playerHealth = gameObject.GetComponent<PlayerHealth>(); // 👈 LOOK HERE 👈
        
        // you don't need to know this
        swordCollider = GetComponentInChildren<CapsuleCollider2D>();
    }
    public void OnFire()
    {
        if (projectilePrefab == null) {
            Debug.LogError("No projectile prefab!");
        }
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
    }

    //TODO: Implement OnSlash() event using Swing() coroutine
    public void OnSwing() {
        if(!IsSlashing) {
            IsSlashing = true;
            StartCoroutine(Swing(.25f));
        }
    }

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
        IsDeflecting = true;
        shield.SetActive(true);

        yield return new WaitForSeconds(deflectTime);
        IsDeflecting = false;
        shield.SetActive(false);
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

                playerHealth.currentHealth -= 1;
                if (playerHealth.currentHealth <= 0) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
