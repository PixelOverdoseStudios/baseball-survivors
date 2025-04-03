using UnityEngine;
using UnityEngine.InputSystem;

public class BatterBasicAttack : MonoBehaviour
{
    public static BatterBasicAttack instance;

    [Header("Config")]
    [SerializeField] private Animator bodyAnimator;

    [Header("Damage per Level")]
    [SerializeField] private int[] damage;
    private int damageLevel;

    [Header("Knock Back per Level")]
    [SerializeField] private float[] knockBackForce;
    private int knockBackLevel;

    [Header("Cooldown per Level")]
    [SerializeField] private float[] attackCooldown;
    private int cooldownLevel;
    private float attackCooldownTimer;

    private int totalWeaponLevelUps;
    private bool autoAttack = false;

    [Header("Cards to Create")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 knockBackCard;
    [SerializeField] private CardTemplateV2 cooldownCard;
    [SerializeField] private CardTemplateV2 specialCard;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        attackCooldownTimer = attackCooldown[cooldownLevel];
        AddStarterCards();
    }

    private void Update()
    {
        attackCooldownTimer += Time.deltaTime;

        if (autoAttack)
        {
            if (attackCooldownTimer > attackCooldown[cooldownLevel])
            {
                bodyAnimator.SetTrigger("attack");
                attackCooldownTimer = 0;
                AudioManager.instance.PlaySFXRandomPitch(1);
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (autoAttack || PauseManager.instance.isPaused) return;

        if (attackCooldownTimer > attackCooldown[cooldownLevel])
        {
            bodyAnimator.SetTrigger("attack");
            attackCooldownTimer = 0;
            AudioManager.instance.PlaySFXRandomPitch(1);
        }
    }

    public void AutoAttackTrigger(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (PauseManager.instance.isPaused) return;

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
        int damageToGive = Mathf.RoundToInt((damage[damageLevel] + GameManager.instance.GetDamageUpgrade()) *
            PlayerLevelingSystem.instance.damageMulti);

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, knockBackForce[knockBackLevel]);
            AudioManager.instance.PlaySFXRandomPitch(0);
        }
    }

    private void AddStarterCards()
    {
        CardHolder.instance.AddCard(damageCard);
        CardHolder.instance.AddCard(knockBackCard);
        CardHolder.instance.AddCard(cooldownCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.batterDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.batterKnockBackIncrease);
        CardHolder.instance.RemoveCard(CardEffect.batterCooldownReduction);
    }

    public void BatterDamageUpgrade()
    {
        damageLevel++;
        TotalWeaponLevelUps();
    }

    public void BatterKnockBackUpgrade()
    {
        knockBackLevel++;
        TotalWeaponLevelUps();
    }

    public void BatterCooldownReduction()
    {
        cooldownLevel++;
        TotalWeaponLevelUps();
    }

    private void TotalWeaponLevelUps()
    {
        totalWeaponLevelUps++;
        if(totalWeaponLevelUps >= 10)
        {
            RemoveStarterCards();
        }
    }
}
