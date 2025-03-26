using UnityEngine;

public class ShopStatUpgrades : MonoBehaviour
{
    public static ShopStatUpgrades instance;

    [Header("Player Stat Upgrades")]
    [SerializeField] private int maxHealthUpgrade;
    [SerializeField] private int baseDamageUpgrade;
    [SerializeField] private int baseDefenseUpgrade;
    [SerializeField] private float baseSpeedUpgrade;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }           
    }

    #region Getting Methods
    public int GetMaxHealthUpgrade() => maxHealthUpgrade;
    public int GetDamageUpgrade() => baseDamageUpgrade;
    public int GetDefenseUpgrade() => baseDefenseUpgrade;
    public float GetSpeedUpgrade() => baseSpeedUpgrade;
    #endregion

    #region Upgrade Methods
    public void UpgradeMaxHealth()
    {
        maxHealthUpgrade++;
    }

    public void UpgradeDamage()
    {
        baseDamageUpgrade++;
    }

    public void UpgradeDefense()
    {
        baseDamageUpgrade++;
    }

    public void UpgradeSpeed()
    {
        baseSpeedUpgrade++;
    }
    #endregion

    #region Misc Methods
    public void ResetShopUpgrades()
    {
        maxHealthUpgrade = 0;
        baseDamageUpgrade = 0;
        baseDefenseUpgrade = 0;
        baseSpeedUpgrade = 0;
    }
    #endregion
}
