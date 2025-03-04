using UnityEngine;
using TMPro;

public class HealthUIText : MonoBehaviour
{
    public TMP_Text healthText; // this is referenced in the inspector, don't worry about it!
    public PlayerHealth playerHealth; // reference to PlayerHealth instance

    void Awake()
    {
        ReferencePlayerHealth();
    }

    void Start()
    {
        healthText.text = "Health: " + "?" + "/" + "?"; // this is the default, a placeholder
    }

    void Update()
    {
        // TODO: update health text dynamically here
        healthText.text = "Health: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }

    public void ReferencePlayerHealth() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();   
    }

}

