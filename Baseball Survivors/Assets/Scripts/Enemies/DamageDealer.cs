using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown = 1f;
    private float attackCooldownCounter;
    private PlayerHealth player;

    private void Update()
    {
        attackCooldownCounter += Time.deltaTime;
        DamagePlayer();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void DamagePlayer()
    {
        if(player != null && attackCooldownCounter >= attackCooldown)
        {
            player.TakeDamage(damage);
            attackCooldownCounter = 0;
        }
    }
}
