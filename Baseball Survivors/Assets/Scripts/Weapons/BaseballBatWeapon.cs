using JetBrains.Annotations;
using UnityEngine;

public class BaseballBatWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject baseballBatPrefab;

    [Header("Number of Bats Level")]
    [SerializeField][Range(1, 3)] private int weaponLevel = 1;
    private int OverallWeaponLevel;

    [Header("Defaults")]
    public float projectileSpeed;
    private float positionTracker = 0;

    [Header("Damage per Level")]
    public int[] damage;
    [HideInInspector] public int damageLevel;

    [Header("Projectile Size per Level")]
    public float[] projectileSize;
    [HideInInspector] public int projectileSizeLevel;

    [Header("Cooldown per Level")]
    public float[] cooldown;
    [HideInInspector] public int cooldownLevel;
    private float cooldownCounter;

    [Header("Starter Cards")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 projectileSizeCard;
    [SerializeField] private CardTemplateV2 cooldownCard;

    [Header("Special Card")]
    [SerializeField] private CardTemplateV2 specialCard;

    public void Start()
    {
        cooldownCounter = cooldown[cooldownLevel] - 0.5f;
        AddStarterCards();
    }

    private void Update()
    {
        cooldownCounter += Time.deltaTime;

        if (cooldownCounter >= cooldown[cooldownLevel] - PlayerLevelingSystem.instance.cooldownBonus)
        {
            switch (weaponLevel)
            {
                case 1:
                    switch (positionTracker)
                    {
                        case 0:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                            positionTracker++;
                            break;
                        case 1:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                            positionTracker++;
                            break;
                        case 2:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                            positionTracker++;
                            break;
                        case 3:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                            positionTracker = 0;
                            break;
                    }
                    cooldownCounter = 0;
                    break;
                case 2:
                    switch (positionTracker)
                    {
                        case 0:
                        case 2:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                            positionTracker++;
                            break;
                        case 1:
                        case 3:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                            positionTracker++;
                            if (positionTracker == 4) positionTracker = 0;
                            break;
                    }
                    cooldownCounter = 0;
                    break;
                case 3:
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                    cooldownCounter = 0;
                    break;
            }
        }
    }
    
    public void LevelUpDamage()
    {
        damageLevel++;
        OverallWeaponLevelUp();
    }

    public void LevelUpProjectileSize()
    {
        projectileSizeLevel++;
        OverallWeaponLevelUp();
    }

    public void LevelUpCooldown()
    {
        cooldownLevel++;
        OverallWeaponLevelUp();
    }

    public void ActivateSpecial()
    {
        weaponLevel++;

        CardHolder.instance.RemoveOneCard(CardEffect.flyingBatsSpecialUnlock);
    }

    private void OverallWeaponLevelUp()
    {
        OverallWeaponLevel++;

        if(OverallWeaponLevel == 3 || OverallWeaponLevel == 6)
        {
            AddSpecialCard();
        }
        else if(OverallWeaponLevel >= 10)
        {
            RemoveStarterCards();
        }
    }

    private void AddStarterCards()
    {
        CardHolder.instance.AddCard(damageCard);
        CardHolder.instance.AddCard(projectileSizeCard);
        CardHolder.instance.AddCard(cooldownCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.flyingBatsDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.flyingBatsProjctileSize);
        CardHolder.instance.RemoveCard(CardEffect.flyingBatsWeaponCooldown);
    }

    private void AddSpecialCard()
    {
        CardHolder.instance.AddCard(specialCard);
    }
}
