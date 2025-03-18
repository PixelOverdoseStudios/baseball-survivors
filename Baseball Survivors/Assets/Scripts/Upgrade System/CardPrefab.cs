using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardType;
    [SerializeField] private TextMeshProUGUI cardDescription;
    private CardEffect cardEffect;

    public void RetrieveData(string _cardName, CardType _cardType, CardEffect _cardEffect, string _cardDescription)
    {
        cardName.text = _cardName;
        cardDescription.text = _cardDescription;
        cardEffect = _cardEffect;

        switch(_cardType)
        {
            case CardType.StatIncrease:
                cardType.text = "Player Stat Increase";
                break;
            case CardType.WeaponUnlock:
                cardType.text = "Weapon Unlock";
                break;
            case CardType.WeaponBoost:
                cardType.text = "Weapon Upgrade";
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

                break;
            case CardEffect.playerDamageIncrease:

                break;
            case CardEffect.playerDefenseIncrease:

                break;
            case CardEffect.playerSpeedIncrease:

                break;
            case CardEffect.playerCooldownReduction:

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
        }

        transform.parent.gameObject.SetActive(false);
    }
}
