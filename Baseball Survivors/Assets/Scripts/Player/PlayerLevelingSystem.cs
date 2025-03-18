using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class PlayerLevelingSystem : MonoBehaviour
{
    public static PlayerLevelingSystem instance;

    [Header("Exp Stats")]
    [SerializeField] private int playerCurrentLevel;
    [SerializeField] private int currentExpPoints;
    [SerializeField] private int expNeededForNextLevel;

    [Header("Exp Bar Hookup")]
    [SerializeField] private Slider expBarSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    [Header("Player Multipliers")]
    public float damageMulti = 1;
    [SerializeField] private float maxDamageMulti = 2;

    [Header("Speed Increase")]
    public float speedIncrease = 0;
    [SerializeField] private float maxSpeedIncrease = 2;

    [Header("Cooldown Bonus")]
    public float cooldownBonus = 0;
    [SerializeField] private float maxCooldownBonus = 0.5f;

    [Header("Defense Bonus")]
    public float defenseBonus = 0;
    [SerializeField] private float maxDefenseBonus = 0.5f;

    [Header("Cards to Create")]
    [SerializeField] private List<CardTemplateV2> statStarterCards;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        playerCurrentLevel = 1;
        UpdateExpSlider();

        //for(int i = 0; i < statStarterCards.Count; i++)
        //{
        //    CardHolder.instance.AddCard(statStarterCards[i]);
        //}
    }

    public void GainExp(int amount)
    {
        currentExpPoints += amount;
        if(currentExpPoints >= expNeededForNextLevel) LevelUp();
        UpdateExpSlider();
    }

    public void LevelUp()
    {
        playerCurrentLevel++;
        currentExpPoints -= expNeededForNextLevel;
        expNeededForNextLevel = Mathf.RoundToInt(expNeededForNextLevel * 1.2f);
        UpdateExpSlider();
    }

    private void UpdateExpSlider()
    {
        expBarSlider.value = currentExpPoints;
        expBarSlider.maxValue = expNeededForNextLevel;
        levelText.text = "Level " + playerCurrentLevel;
    }

    public void UpgradeMaxHealth()
    {
        PlayerHealth.instance.RaiseMaxHealth(5);

        if(PlayerHealth.instance.GetPlayerMaxHealth() >= 30 )
        {
            CardHolder.instance.RemoveCard("Max Health+");
        }
    }

    public void UpgradeDamageMulti()
    {
        damageMulti += 0.1f;

        if(damageMulti >= maxDamageMulti)
        {
            CardHolder.instance.RemoveCard("Damage Multiplier");
        }
    }

    public void UpgradeSpeedIncrease()
    {
        speedIncrease += 0.2f;

        if(speedIncrease >= maxSpeedIncrease)
        {
            CardHolder.instance.RemoveCard("Speed Increase");
        }
    }

    public void UpgradeCooldownBonus()
    {
        cooldownBonus += 0.05f;

        if(cooldownBonus >= maxCooldownBonus)
        {
            CardHolder.instance.RemoveCard("Cooldown Reduction Multiplier");
        }
    }

    public void UpgradePlayerDefense()
    {
        defenseBonus += 0.05f;

        if(defenseBonus >= maxDefenseBonus)
        {
            CardHolder.instance.RemoveCard("Defense Buff");
        }
    }
}
