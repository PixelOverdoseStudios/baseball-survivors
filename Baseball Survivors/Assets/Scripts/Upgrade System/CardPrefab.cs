using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardType;
    [SerializeField] private TextMeshProUGUI cardDescription;
    private CardEffect cardEffect;
    private Image backgroundImage;

    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }

    public void RetrieveData(Sprite _sprite, string _cardName, CardType _cardType, CardEffect _cardEffect, string _cardDescription)
    {
        if(_sprite != null)
        {
            backgroundImage.sprite = _sprite;
        }

        cardName.text = _cardName;
        cardDescription.text = _cardDescription;
        cardEffect = _cardEffect;

        switch(_cardType)
        {
            case CardType.StatIncrease:
                cardType.text = "Stat Increase";
                break;
            case CardType.WeaponUnlock:
                cardType.text = "Weapon Unlock";
                break;
            case CardType.WeaponBoost:
                cardType.text = "Weapon Upgrade";
                break;
            case CardType.Special:
                cardType.text = "Special Unlock";
                break;
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    public void ActivateCardEffect()
    {
        switch(cardEffect)
        {
            //=== ALL PLAYER STATS ===//
            case CardEffect.playerHealthIncrease:
                PlayerLevelingSystem.instance.UpgradeMaxHealth();
                break;
            case CardEffect.playerDamageIncrease:
                PlayerLevelingSystem.instance.UpgradeDamageMulti();
                break;
            case CardEffect.playerDefenseIncrease:
                PlayerLevelingSystem.instance.UpgradePlayerDefense();
                break;
            case CardEffect.playerSpeedIncrease:
                PlayerLevelingSystem.instance.UpgradeSpeedIncrease();
                break;
            case CardEffect.playerCooldownReduction:
                PlayerLevelingSystem.instance.UpgradeCooldownBonus();
                break;

            //=== PLAYER 1 BATTER UNLOCKS ===//
            case CardEffect.batterDamageIncrease:
                BatterBasicAttack.instance.BatterDamageUpgrade();
                break;
            case CardEffect.batterKnockBackIncrease:
                BatterBasicAttack.instance.BatterKnockBackUpgrade();
                break;
            case CardEffect.batterCooldownReduction:
                BatterBasicAttack.instance.BatterCooldownReduction();
                break;
            case CardEffect.batterSpecialUnlock:
                break;

            //=== WEAPON UNLOCKS ===//
            case CardEffect.spinningBallsWeaponUnlock:
                WeaponReference.instance.UnlockSpinningBaseballs();
                break;
            case CardEffect.flyingBatsWeaponUnlock:
                WeaponReference.instance.UnlockBaseballBatWeapon();
                break;
            case CardEffect.frozenPopsWeaponUnlock:
                WeaponReference.instance.UnlockFrozenPops();
                break;
            case CardEffect.areaOfEffectWeaponUnlock:
                WeaponReference.instance.UnlockAreaOfEffect();
                break;
            case CardEffect.ballLauncherWeaponUnlock:
                WeaponReference.instance.UnlockBallLauncher();
                break;

            //=== SPINNING BALLS UPGRADES ===//
            case CardEffect.spinningBallsDamageIncrease:
                WeaponReference.instance.SpinningBallsLevelUpDamage();
                break;
            case CardEffect.spinningBallsRotationSpeed:
                WeaponReference.instance.SpinningBallsLevelUpRotation();
                break;
            case CardEffect.spinningBallsCooldownReduction:
                WeaponReference.instance.SpinningBallsLevelUpCooldown();
                break;
            case CardEffect.spinningBallsSpecialUnlock:
                WeaponReference.instance.SpinningBallsLevelUpSpecial();
                break;

            //=== FLYING BATS UPGRADES ===//
            case CardEffect.flyingBatsDamageIncrease:
                WeaponReference.instance.FlyingBatLevelUpDamage();
                break;
            case CardEffect.flyingBatsProjctileSize:
                WeaponReference.instance.FlyingBatLevelUpProjectileSize();
                break;
            case CardEffect.flyingBatsWeaponCooldown:
                WeaponReference.instance.FlyingBatLevelUpCooldown();
                break;
            case CardEffect.flyingBatsSpecialUnlock:
                WeaponReference.instance.FlyingBatLevelUpSpecial();
                break;

            //=== FROZEN POPS UPGRADES ===//
            case CardEffect.frozenPopsDamageIncrease:
                WeaponReference.instance.FrozenPopLevelUpDamage();
                break;
            case CardEffect.frozenPopsSlowIncrease:
                WeaponReference.instance.FrozenPopLevelUpSlowDuration();
                break;
            case CardEffect.frozenPopsCooldownReduction:
                WeaponReference.instance.FrozenPopLevelUpCooldown();
                break;
            case CardEffect.frozenPopsSpecialUnlock:
                WeaponReference.instance.FrozenPopLevelUpSpecial();
                break;

            //=== AREA OF EFFECT UPGRADES ===//
            case CardEffect.areaOfEffectDamageIncrease:
                WeaponReference.instance.AreaOfEffectLevelUpDamage();
                break;
            case CardEffect.areaOfEffectCooldownReduction:
                WeaponReference.instance.AreaOfEffectLevelUpCooldown();
                break;
            case CardEffect.areaOfEffectRadiusIncrease:
                WeaponReference.instance.AreaOfEffectLevelUpTargetSize();
                break;
            case CardEffect.areaOfEffectSpecialUnlock:
                WeaponReference.instance.AreaOfEffectLevelUpSpecial();
                break;

            //=== BALL LAUNCHER UPGRADES ===//
            case CardEffect.ballLauncherDamageIncrease:
                WeaponReference.instance.BallLauncherLevelUpDamage();
                break;
            case CardEffect.ballLauncherFireRate:
                WeaponReference.instance.BallLauncherLevelUpFireRate();
                break;
            case CardEffect.ballLauncherCooldownReduction:
                WeaponReference.instance.BallLauncherLevelUpCooldown();
                break;
            case CardEffect.ballLauncherSpecialUnlock:
                WeaponReference.instance.BallLauncherLevelUpSpecial();
                break;
        }

        transform.parent.gameObject.SetActive(false);
    }
}
