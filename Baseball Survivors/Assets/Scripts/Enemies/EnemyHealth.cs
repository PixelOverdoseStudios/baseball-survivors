using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private int amountOfExp = 1;

    private SpriteRenderer sr;
    private EnemyBrain enemyBrain;
    private Vector3 offset = new Vector3(0f, 0.65f, 0);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        enemyBrain = GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int value)
    {
        currentHealth -= Mathf.RoundToInt(value * PlayerLevelingSystem.instance.damageMulti);
        StartCoroutine(FlashRedCo());
        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + offset, Quaternion.identity);
            PlayerLevelingSystem.instance.GainExp(amountOfExp);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int value, float knockBackForce)
    {
        currentHealth -= value;
        StartCoroutine(FlashRedCo());
        enemyBrain.CanKnockBackCheck(knockBackForce);
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + offset, Quaternion.identity);
            PlayerLevelingSystem.instance.GainExp(amountOfExp);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int value, float timeOfEffect, StatusEffect statusEffect)
    {
        currentHealth -= value;
        if(statusEffect == StatusEffect.slowed)
        {
            enemyBrain.EnemyIsSlowed(timeOfEffect);
        }
        else if(statusEffect == StatusEffect.frozen)
        {
            enemyBrain.EnemyIsFrozen(timeOfEffect);
        }
        StartCoroutine(FlashRedCo());
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + offset, Quaternion.identity);
            PlayerLevelingSystem.instance.GainExp(amountOfExp);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator FlashRedCo()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyBrain.CheckColorSprite();
    }
}

public enum StatusEffect
{
    slowed,
    frozen
}
