using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Numbers")]
    [SerializeField] private float maxHealth = 5f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void HealHealth(float amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void RaiseMaxHealth(float amount)
    {
        maxHealth += amount;
        HealHealth(amount);
    }
}
