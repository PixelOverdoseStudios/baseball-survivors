using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;

    [Header("Player Stats")]
    //health variables
    [SerializeField] private int maxHealth;
    private int currentHealth;

    //leveling variables
    [SerializeField] private int playerCurrentLevel;
    [SerializeField] private int currentExpPoints;
    private int expNeededForNextLevel;

    //other variables




    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
}
