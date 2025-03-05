using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject deathEffect;

    private SpriteRenderer sr;
    private EnemyBrain enemyBrain;

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
        currentHealth -= value;
        StartCoroutine(FlashRedCo());
        StartCoroutine(enemyBrain.KnockBackCo());
        Vector3 offset = new Vector3(0f, 0.65f, 0);
        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + offset, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator FlashRedCo()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
