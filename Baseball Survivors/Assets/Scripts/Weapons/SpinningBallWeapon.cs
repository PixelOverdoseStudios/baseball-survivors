using UnityEngine;

public class SpinningBallWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject baseballPrefab;
    public float distanceSpeed;
    public float growingSpeed;
    private int overallWeaponLevel;

    [Header("Stats")]
    [SerializeField] [Range(1, 3)] private int numberOfBalls = 1;
    public float range;
    public float ballSize;
    public float duration;

    [Header("Damage per Level")]
    public int[] damage;
    [HideInInspector] public int damageLevel;

    [Header("Rotation Speed per Level")]
    public float[] rotationSpeed;
    [HideInInspector] public int rotationSpeedLevel;

    [Header("Cooldown per Level")]
    public float[] weaponCooldown;
    [HideInInspector] public int weaponCooldownLevel;
    private float cooldownCounter;

    [Header("Spawning Locations")]
    [SerializeField] private Transform degree0SpawnPoint;
    [SerializeField] private Transform degree120SpawnPoint;
    [SerializeField] private Transform degree180SpawnPoint;
    [SerializeField] private Transform degree240SpawnPoint;

    [Header("Starter Cards")]
    [SerializeField] private CardTemplateV2 damageCard;
    [SerializeField] private CardTemplateV2 cooldownCard;
    [SerializeField] private CardTemplateV2 rotationSpeedCard;

    [Header("Special Card")]
    [SerializeField] private CardTemplateV2 specialCard;

    private void Start()
    {
        cooldownCounter = weaponCooldown[weaponCooldownLevel] + duration - 0.5f;
        AddStarterCards();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, -rotationSpeed[rotationSpeedLevel] * Time.deltaTime);

        cooldownCounter += Time.deltaTime;
        if(cooldownCounter >= (weaponCooldown[weaponCooldownLevel] * PlayerLevelingSystem.instance.cooldownBonus) + duration)
        {
            switch(numberOfBalls)
            {
                case 1:
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation, 
                        degree0SpawnPoint.transform);
                    break;
                case 2:
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation,
                        degree0SpawnPoint.transform);                    
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation,
                        degree180SpawnPoint.transform);
                    break;
                case 3:
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree0SpawnPoint.transform);
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree120SpawnPoint.transform);
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree240SpawnPoint.transform);
                    break;
            }
            cooldownCounter = 0;
        }
    }

    public void UpgradeDamage()
    {
        damageLevel++;
        OverallWeaponLevelIncrease();
    }

    public void UpgradeCooldown()
    {
        weaponCooldownLevel++;
        OverallWeaponLevelIncrease();
    }

    public void UpgradeRotation()
    {
        overallWeaponLevel++;
        OverallWeaponLevelIncrease();
    }

    public void ActivateSpecial()
    {
        numberOfBalls++;

        CardHolder.instance.RemoveOneCard(CardEffect.spinningBallsSpecialUnlock);
    }

    private void OverallWeaponLevelIncrease()
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
        CardHolder.instance.AddCard(cooldownCard);
        CardHolder.instance.AddCard(rotationSpeedCard);
    }

    private void RemoveStarterCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.spinningBallsDamageIncrease);
        CardHolder.instance.RemoveCard(CardEffect.spinningBallsCooldownReduction);
        CardHolder.instance.RemoveCard(CardEffect.spinningBallsRotationSpeed);
    }

    private void AddSpecialCard()
    {
        CardHolder.instance.AddCard(specialCard);
    }
}
