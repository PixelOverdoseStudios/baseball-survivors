using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherWeapon : MonoBehaviour
{
    [SerializeField] private GameObject ballLauncherObject;
    public float turretLifeTime;
    public float detectionRadius;
    public float projectileSpeed;
    private int overallWeaponLevel;

    [Header("Damage per Level")]
    public int[] damage;
    [HideInInspector] public int damageLevel;

    [Header("Fire Rate per Level")]
    public float[] fireRate;
    [HideInInspector] public int fireRateLevel;

    [Header("Cooldown per Level")]
    [SerializeField] private float[] spawningCooldown;
    private int spawningCooldownLevel;
    private float cooldownTimer;

    [Header("Starter Cards")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 fireRateCard;
    [SerializeField] private CardTemplateV2 cooldownCard;

    [Header("Special Card")]
    [SerializeField] private CardTemplateV2 specialCard;

    private void Start()
    {
        cooldownTimer = spawningCooldown[spawningCooldownLevel] - 0.5f;
        AddStarterCards();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= spawningCooldown[spawningCooldownLevel] - PlayerLevelingSystem.instance.cooldownBonus)
        {
            Instantiate(ballLauncherObject, transform.position, Quaternion.identity);
            cooldownTimer = 0;
        }
    }

    public void LevelUpDamage()
    {
        damageLevel++;
        OverallWeaponLevelUp();
    }

    public void LevelUpFireRate()
    {
        fireRateLevel++;
        OverallWeaponLevelUp();
    }

    public void LevelUpCooldown()
    {
        spawningCooldownLevel++;
        OverallWeaponLevelUp();
    }

    public void ActivateSpecial()
    {
        detectionRadius += 2;

        CardHolder.instance.RemoveOneCard(CardEffect.ballLauncherSpecialUnlock);
    }

    private void OverallWeaponLevelUp()
    {
        overallWeaponLevel++;
        
        if(overallWeaponLevel == 3 || overallWeaponLevel == 6)
        {
            AddSpecialCard();
        }
        else if(overallWeaponLevel >= 10)
        {
            RemoveStarterCards();
        }
    }

    private void AddStarterCards()
    {
        CardHolder.instance.AddCard(damageCard);
        CardHolder.instance.AddCard(fireRateCard);
        CardHolder.instance.AddCard(cooldownCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.ballLauncherDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.ballLauncherFireRate);
        CardHolder.instance.RemoveCard(CardEffect.ballLauncherCooldownReduction);
    }

    private void AddSpecialCard()
    {
        CardHolder.instance.AddCard(specialCard);
    }
}
