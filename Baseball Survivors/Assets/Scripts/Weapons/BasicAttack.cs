using UnityEngine;
using UnityEngine.InputSystem;

public class BasicAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Animator bodyAnimator;

    [Header("Stats")]
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    private float attackCooldownTimer;
    private bool autoAttack = false;

    private void Start()
    {
        attackCooldownTimer = attackCooldown;
    }

    private void Update()
    {
        attackCooldownTimer += Time.deltaTime;

        if (autoAttack)
        {
            if (attackCooldownTimer > attackCooldown)
            {
                bodyAnimator.SetTrigger("attack");
                attackCooldownTimer = 0;
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (autoAttack) return;

        if (attackCooldownTimer > attackCooldown)
        {
            bodyAnimator.SetTrigger("attack");
            attackCooldownTimer = 0;
        }
    }

    public void AutoAttackTrigger(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (autoAttack)
        {
            autoAttack = false;
        }
        else
        {
            autoAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
