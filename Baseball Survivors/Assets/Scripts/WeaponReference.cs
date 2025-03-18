using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReference : MonoBehaviour
{
    public static WeaponReference instance;

    [Header("Config")]
    [SerializeField] private int maxWeaponCount = 1;
    private int currentWeaponCount;

    [Header("Weapon References")]
    [SerializeField] private GameObject spinningBaseballWeapon;
    [SerializeField] private GameObject baseballBatWeapon;
    [SerializeField] private GameObject frozenPopsWeapon;
    [SerializeField] private GameObject areaOfEffectWeapon;
    [SerializeField] private GameObject ballLauncherWeapon;

    [Header("Cards to Create")]
    [SerializeField] private List<CardTemplateV2> weaponStarterCards;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < weaponStarterCards.Count; i++)
        {
            CardHolder.instance.AddCard(weaponStarterCards[i]);
        }
    }

    public void UnlockBaseballBatWeapon()
    {
        if(!baseballBatWeapon.activeInHierarchy)
        {
            baseballBatWeapon.SetActive(true);
            CardHolder.instance.RemoveCard("Flying Baseball Bats");
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockSpinningBaseballs()
    {
        if (!spinningBaseballWeapon.activeInHierarchy)
        {
            spinningBaseballWeapon.SetActive(true);
            CardHolder.instance.RemoveCard("Spinning Balls");
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockFrozenPops()
    {
        if (!frozenPopsWeapon.activeInHierarchy)
        {
            frozenPopsWeapon.SetActive(true);
            CardHolder.instance.RemoveCard("Frozen Pops");
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockAreaOfEffect()
    {
        if (!areaOfEffectWeapon.activeInHierarchy)
        {
            areaOfEffectWeapon.SetActive(true);
            CardHolder.instance.RemoveCard("Area of Effect");
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockBallLauncher()
    {
        if (!ballLauncherWeapon.activeInHierarchy)
        {
            ballLauncherWeapon.SetActive(true);
            CardHolder.instance.RemoveCard("Ball Launcher");
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    private void CheckForWeaponLimit()
    {
        if(currentWeaponCount >= maxWeaponCount)
        {
            for(int i = 0; i < weaponStarterCards.Count; i++)
            {
                CardHolder.instance.RemoveCard(weaponStarterCards[i].cardName);
            }
        }
    }

    //Area of Effect Level Up References
    public void AreaOfEffectLevelUpDamage() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpDamage();
    public void AreaOfEffectLevelUpTargetSize() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpTargetSize();
    public void AreaOfEffectLevelUpCooldown() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpCooldown();
    public void AreaOfEffectLevelUpSpecial() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpSpecial();
}
