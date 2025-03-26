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
    [SerializeField] private CardTemplateV2 spinningBallsUnlockCard;
    [SerializeField] private CardTemplateV2 flyingBatsUnlockCard;
    [SerializeField] private CardTemplateV2 frozenPopsUnlockCard;
    [SerializeField] private CardTemplateV2 areaOfEffectUnlockCard;
    [SerializeField] private CardTemplateV2 ballLauncherUnlockCard;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        AddStarterCards();
    }

    public void UnlockBaseballBatWeapon()
    {
        if(!baseballBatWeapon.activeInHierarchy)
        {
            baseballBatWeapon.SetActive(true);
            CardHolder.instance.RemoveCard(CardEffect.flyingBatsWeaponUnlock);
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockSpinningBaseballs()
    {
        if (!spinningBaseballWeapon.activeInHierarchy)
        {
            spinningBaseballWeapon.SetActive(true);
            CardHolder.instance.RemoveCard(CardEffect.spinningBallsWeaponUnlock);
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockFrozenPops()
    {
        if (!frozenPopsWeapon.activeInHierarchy)
        {
            frozenPopsWeapon.SetActive(true);
            CardHolder.instance.RemoveCard(CardEffect.frozenPopsWeaponUnlock);
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockAreaOfEffect()
    {
        if (!areaOfEffectWeapon.activeInHierarchy)
        {
            areaOfEffectWeapon.SetActive(true);
            CardHolder.instance.RemoveCard(CardEffect.areaOfEffectWeaponUnlock);
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    public void UnlockBallLauncher()
    {
        if (!ballLauncherWeapon.activeInHierarchy)
        {
            ballLauncherWeapon.SetActive(true);
            CardHolder.instance.RemoveCard(CardEffect.ballLauncherWeaponUnlock);
            currentWeaponCount++;
            CheckForWeaponLimit();
        }
    }

    private void CheckForWeaponLimit()
    {
        if(currentWeaponCount >= maxWeaponCount)
        {
            RemoveStartCards();
        }
    }

    private void AddStarterCards()
    {
        CardHolder.instance.AddCard(spinningBallsUnlockCard);
        CardHolder.instance.AddCard(flyingBatsUnlockCard);
        CardHolder.instance.AddCard(frozenPopsUnlockCard);
        CardHolder.instance.AddCard(areaOfEffectUnlockCard);
        CardHolder.instance.AddCard(ballLauncherUnlockCard);
    }

    private void RemoveStartCards()
    {
        CardHolder.instance.RemoveCard(CardEffect.spinningBallsWeaponUnlock);
        CardHolder.instance.RemoveCard(CardEffect.flyingBatsWeaponUnlock);
        CardHolder.instance.RemoveCard(CardEffect.frozenPopsWeaponUnlock);
        CardHolder.instance.RemoveCard(CardEffect.areaOfEffectWeaponUnlock);
        CardHolder.instance.RemoveCard(CardEffect.ballLauncherWeaponUnlock);
    }

    //=== SPINNING BALLS REFERENCES ===//
    public void SpinningBallsLevelUpDamage() => spinningBaseballWeapon.GetComponent<SpinningBallWeapon>().UpgradeDamage();
    public void SpinningBallsLevelUpRotation() => spinningBaseballWeapon.GetComponent<SpinningBallWeapon>().UpgradeRotation();
    public void SpinningBallsLevelUpCooldown() => spinningBaseballWeapon.GetComponent<SpinningBallWeapon>().UpgradeCooldown();
    public void SpinningBallsLevelUpSpecial() => spinningBaseballWeapon.GetComponent<SpinningBallWeapon>().ActivateSpecial();

    //=== FLYING BATS REFERENCES ===//
    public void FlyingBatLevelUpDamage() => baseballBatWeapon.GetComponent<BaseballBatWeapon>().LevelUpDamage();
    public void FlyingBatLevelUpProjectileSize() => baseballBatWeapon.GetComponent<BaseballBatWeapon>().LevelUpProjectileSize();
    public void FlyingBatLevelUpCooldown() => baseballBatWeapon.GetComponent<BaseballBatWeapon>().LevelUpCooldown();
    public void FlyingBatLevelUpSpecial() => baseballBatWeapon.GetComponent<BaseballBatWeapon>().ActivateSpecial();

    //=== FROZEN POPS REFERENCES ===//
    public void FrozenPopLevelUpDamage() => frozenPopsWeapon.GetComponent<FrozenPopsWeapon>().DamageLevelUp();
    public void FrozenPopLevelUpSlowDuration() => frozenPopsWeapon.GetComponent<FrozenPopsWeapon>().SlowDurationLevelUp();
    public void FrozenPopLevelUpCooldown() => frozenPopsWeapon.GetComponent<FrozenPopsWeapon>().CooldownLevelUp();
    public void FrozenPopLevelUpSpecial() => frozenPopsWeapon.GetComponent<FrozenPopsWeapon>().ActivateSpecial();

    //=== AREA OF EFFECT REFERENCES ===//
    public void AreaOfEffectLevelUpDamage() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpDamage();
    public void AreaOfEffectLevelUpTargetSize() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpTargetSize();
    public void AreaOfEffectLevelUpCooldown() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpCooldown();
    public void AreaOfEffectLevelUpSpecial() => areaOfEffectWeapon.GetComponent<AreaOfEffectWeapon>().LevelUpSpecial();

    //=== BALL LAUNCHER REFERENCES ===//
    public void BallLauncherLevelUpDamage() => ballLauncherWeapon.GetComponent<BallLauncherWeapon>().LevelUpDamage();
    public void BallLauncherLevelUpFireRate() => ballLauncherWeapon.GetComponent<BallLauncherWeapon>().LevelUpFireRate();
    public void BallLauncherLevelUpCooldown() => ballLauncherWeapon.GetComponent<BallLauncherWeapon>().LevelUpCooldown();
    public void BallLauncherLevelUpSpecial() => ballLauncherWeapon.GetComponent<BallLauncherWeapon>().ActivateSpecial();
}
