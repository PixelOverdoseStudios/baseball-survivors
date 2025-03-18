using JetBrains.Annotations;
using UnityEngine;

public class BaseballBatWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject baseballBatPrefab;

    [Header("Number of Bats Level")]
    [SerializeField][Range(1, 3)] private int weaponLevel = 1;

    [Header("Damage Output")]
    [SerializeField] private int startingDamage;
    [SerializeField] private int damageAddedPerLevel;
    [SerializeField] private int damageLevelCounter;
    [HideInInspector] public int currentDamage;

    [Header("Projectile Size")]
    [SerializeField] private float startingProjectileSize;
    [SerializeField] private float sizeMultiplier;
    [SerializeField] private float sizeLevelCounter;
    [HideInInspector] public float currentProjectileSize;

    [Header("Cooldown")]
    [SerializeField] private float startingCooldown;
    [SerializeField] private float cooldownMultiplier;
    [SerializeField] private float cooldownLevelCounter;
    [HideInInspector] public float currentCooldown;

    [Header("Defaults")]
    //[SerializeField] private float projectileSpeed;

    public int damage;
    public float projectileSpeed;
    public float projectileSize;
    public float weaponCooldown;

    private float cooldownCounter;
    private float positionTracker = 0;

    public void Start()
    {
        cooldownCounter = weaponCooldown - 0.5f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            CardTemplate damageBoostCard = new CardTemplate();

            damageBoostCard.upgradeName = "Baseball Bat Damage+";
            damageBoostCard.upgradeDescription = "Increases damage done by baseball bat.";
            damageBoostCard.cardItemNum = 1;

            //UpgradeManager.instance.CreateNewCard(damageBoostCard);
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            //UpgradeManager.instance.RemoveCard(1);
        }

        cooldownCounter += Time.deltaTime;

        if (cooldownCounter >= weaponCooldown)
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

    public void CreateDamageBoostCard()
    {
        //damageBoostCard.upgradeName = "Baseball Bat Damage+";
        //damageBoostCard.upgradeDescription = "Increases damage done by baseball bat.";
    }
    //    public string upgradeName;
    //public int upgradeLevel = 0;
    //public string upgradeDescription;

    public void TestingFunction()
    {
        Debug.Log("Connection works!");
    }
}
