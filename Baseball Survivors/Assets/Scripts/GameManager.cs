using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, ISaveManager
{
    public static GameManager instance;

    [Header("Player Stat Upgrades")]
    [SerializeField] private int maxHealthUpgrade;
    [SerializeField] private int baseDamageUpgrade;
    [SerializeField] private int baseDefenseUpgrade;
    [SerializeField] private float baseSpeedUpgrade;

    [Header("other")]
    [SerializeField] private int currency;

    [Header("Pool of Player Characters")]
    [SerializeField] private int activeCharacterIndex;
    [SerializeField] private GameObject[] playableCharacters;

    [Header("Selecting Map")]
    [SerializeField] private int mapButtonIndex;
    [SerializeField] private string mapSelectedToLoad;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
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

    //=== Selecting Players from lobby ===//
    public void ChangePlayerIndex(int _index) => activeCharacterIndex = _index;
    public int GetActivePlayerIndex => activeCharacterIndex;
    public GameObject GetActivePlayerObject => playableCharacters[activeCharacterIndex];

    //=== Select map to load ===//
    public void ChangeMapButtonIndex(int _index) => mapButtonIndex = _index;
    public int GetMapButtonIndex => mapButtonIndex;
    public void ChangeMapToLoad(string _sceneName) => mapSelectedToLoad = _sceneName;
    public string GetMapToLoad => mapSelectedToLoad;

    public void LoadData(GameData _data)
    {
        this.currency = _data.currency;
        this.activeCharacterIndex = _data.activePlayerIndex;
        this.mapButtonIndex = _data.mapButtonIndex;
        this.mapSelectedToLoad = _data.mapSelectedToLoad;
    }

    public void SaveData(ref GameData _data)
    {
        _data.currency = this.currency;
        _data.activePlayerIndex = this.activeCharacterIndex;
        _data.mapButtonIndex = this.mapButtonIndex;
        _data.mapSelectedToLoad = this.mapSelectedToLoad;
    }
}
