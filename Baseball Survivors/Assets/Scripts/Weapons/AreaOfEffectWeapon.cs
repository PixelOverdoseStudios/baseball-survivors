using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject areaOfEffectPrefab;

    [Header("Non Adjusting Stats")]
    [SerializeField] private int overallNumberOfUpgrades;
    public float duration;
    public float timeBetweenDamage;
    public float specialKnockBackForce;

    [Header("Damage per Level")]
    public int[] damage;
    [HideInInspector] public int damageLevel;

    [Header("Radius per Level")]
    public float[] targetSize;
    [HideInInspector] public int radiusLevel;

    [Header("Cooldown per Level")]
    [SerializeField] private float[] cooldown;
    [HideInInspector] public int cooldownLevel;
    private float cooldownTimer;

    [Header("Cards to Create")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 cooldownCard;
    [SerializeField] private CardTemplateV2 radiusCard;

    [Header("Special Card")]
    [SerializeField] private CardTemplateV2 specialCard;
    private int specialLevel = 0;


    private void Start()
    {
        cooldownTimer = cooldown[cooldownLevel] - 0.5f;
        AddStarterCards();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= (cooldown[cooldownLevel] * PlayerLevelingSystem.instance.cooldownBonus) + duration)
        {
            Instantiate(areaOfEffectPrefab, transform);
            cooldownTimer = 0;
        }
    }

    public void LevelUpDamage()
    {
        damageLevel++;
        OverallWeaponUpgradeIncrease();
    }

    public void LevelUpTargetSize()
    {
        radiusLevel++;
        OverallWeaponUpgradeIncrease();
    }

    public void LevelUpCooldown()
    {
        cooldownLevel++;
        cooldown[cooldownLevel] += duration;
        OverallWeaponUpgradeIncrease();
    }

    public int SpecialLevel() => specialLevel;

    public void ActivateSpecial()
    {
        specialLevel++;
        CardHolder.instance.RemoveOneCard(CardEffect.areaOfEffectSpecialUnlock);
    }

    private void OverallWeaponUpgradeIncrease()
    {
        overallNumberOfUpgrades++;

        if (overallNumberOfUpgrades == 3 || overallNumberOfUpgrades == 6)
        {
            CardHolder.instance.AddCard(specialCard);
        }
        else if (overallNumberOfUpgrades >= 10)
        {
            RemoveStarterCards();
        }
    }

    private void AddStarterCards()
    {
        CardHolder.instance.AddCard(damageCard);
        CardHolder.instance.AddCard(cooldownCard);
        CardHolder.instance.AddCard(radiusCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.areaOfEffectDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.areaOfEffectRadiusIncrease);
        CardHolder.instance.RemoveCard(CardEffect.areaOfEffectCooldownReduction);
    }
}
