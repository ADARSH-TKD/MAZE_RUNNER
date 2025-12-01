using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem; // <--- THIS IS THE MISSING LINE

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    [Header("UI References")]
    public Image frontHealthBar;
    public Image backHealthBar;

    void Start()
    {
        health = maxHealth;
    }

void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (Keyboard.current != null)
        {
            // Changed from 'aKey' to 'zKey'
            if (Keyboard.current.zKey.wasPressedThisFrame) 
            {
                TakeDamage(Random.Range(5, 10));
            }

            // Changed from 'sKey' to 'xKey'
            if (Keyboard.current.xKey.wasPressedThisFrame) 
            {
                RestoreHealth(Random.Range(5, 10));
            }
        }
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if (fillB > hFraction) 
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction) 
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
}