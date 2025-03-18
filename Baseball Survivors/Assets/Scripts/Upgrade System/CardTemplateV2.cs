using UnityEngine;

[System.Serializable]
public class CardTemplateV2
{
    public string cardName;
    public CardType cardType;
    public CardEffect cardEffect;
    [TextArea(3, 10)]
    public string cardDescription;
}

public enum CardType
{
    StatIncrease,
    WeaponUnlock,
    WeaponBoost
}

public enum CardEffect
{
    //=== ALL PLAYER STATS ===//
    playerHealthIncrease,
    playerDamageIncrease,
    playerDefenseIncrease,
    playerSpeedIncrease,
    playerCooldownReduction,

    //=== WEAPON UNLOCKS ===//
    spinningBallsWeaponUnlock,
    flyingBatsWeaponUnlock,
    frozenPopsWeaponUnlock,
    areaOfEffectWeaponUnlock,
    ballLauncherWeaponUnlock,

    //=== SPINNING BALLS UPGRADES ===//
    spinningBallsDamageIncrease,
    spinningBallsDurationIncrease,
    spinningBallsCooldownReduction,
    spinningBallsSpecialUnlock,

    //=== FLYING BATS UPGRADES ===//
    flyingBatsDamageIncrease,
    flyingBatsProjctileSize,
    flyingBatsWeaponCooldown,
    flyingBatsSpecialUnlock,

    //=== FROZEN POPS UPGRADES ===//
    frozenPopsDamageIncrease,
    frozenPopsSlowIncrease,
    frozenPopsCooldownReduction,
    frozenPopsSpecialUnlock,

    //=== AREA OF EFFECT UPGRADES ===//
    areaOfEffectDamageIncrease,
    areaOfEffectRadiusIncrease,
    areaOfEffectCooldownReduction,
    areaOfEffectSpecialUnlock,

    //=== BALL LAUNCHER UPGRADES ===//
    ballLauncherDamageIncrease,
    ballLauncherFireRate,
    ballLauncherCooldownReduction,
    ballLauncherSpecialUnlock
}
