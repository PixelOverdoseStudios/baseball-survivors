using UnityEngine;

public class FrozenPopsWeapon : MonoBehaviour
{
    [SerializeField] private GameObject frozenPopPrefab;

    [Header("Defaults")]
    public int projectileSpeed;
    private int spawnPosition;
    private int overallWeaponLevel;

    [Header("Damage per Level")]
    public int[] damage;
    [HideInInspector] public int damageLevel;

    [Header("Slow Duration per Level")]
    public float[] slowDuration;
    [HideInInspector] public int slowDurationLevel;

    [Header("Cooldown per Level")]
    public float[] cooldown;
    [HideInInspector] public int cooldownLevel;
    private float cooldownCounter;

    [Header("Starter Cards")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 slowDurationCard;
    [SerializeField] private CardTemplateV2 cooldownCard;

    [Header("Special Card")]
    [SerializeField] private CardTemplateV2 specialCard;
    private int specialLevel = 0;

    private void Start()
    {
        cooldownCounter = cooldown[cooldownLevel] - 0.5f;
        AddStarterCards();
    }

    private void Update()
    {
        cooldownCounter += Time.deltaTime;

        if(cooldownCounter >= cooldown[cooldownLevel] - PlayerLevelingSystem.instance.cooldownBonus)
        {
            ShootPrefab();
            cooldownCounter = 0;
        }
    }

    private void ShootPrefab()
    {
        float degreeChange;

        switch(spawnPosition)
        {
            case 0:
                degreeChange = 45f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 1:
                degreeChange = 0f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 2:
                degreeChange = 315f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 3:
                degreeChange = 270f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 4:
                degreeChange = 225f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 5:
                degreeChange = 180f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 6:
                degreeChange = 135f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 7:
                degreeChange = 90f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
        }
    }

    private void UpdateSpawnPosition()
    {
        spawnPosition++;
        if(spawnPosition >= 8) spawnPosition = 0;
    }

    public void DamageLevelUp()
    {
        damageLevel++;
        OverallWeaponLevelUp();
    }

    public void SlowDurationLevelUp()
    {
        slowDurationLevel++;
        OverallWeaponLevelUp();
    }

    public void CooldownLevelUp()
    {
        cooldownLevel++;
        OverallWeaponLevelUp();
    }

    public void ActivateSpecial()
    {
        specialLevel++;

        CardHolder.instance.RemoveOneCard(CardEffect.frozenPopsSpecialUnlock);
    }

    public int GetSpecialLevel() => specialLevel;

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
        CardHolder.instance.AddCard(slowDurationCard);
        CardHolder.instance.AddCard(cooldownCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.frozenPopsDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.frozenPopsSlowIncrease);
        CardHolder.instance.RemoveCard(CardEffect.frozenPopsCooldownReduction);
    }

    private void AddSpecialCard()
    {
        CardHolder.instance.AddCard(specialCard);
    }
}
