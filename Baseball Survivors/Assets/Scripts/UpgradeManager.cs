using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [Header("Config")]
    public GameObject cardPrefab;
    public List<CardTemplate> cardUpgrades;
    private int weaponCounter;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    //private void OnEnable()
    //{
    //    UpdateUpgradeCards();
    //}

    //private void OnDisable()
    //{
    //    CardRemovalChecker();
    //}

    //    private void UpdateUpgradeCards()
    //    {
    //        if (cardUpgrades.Count == 0) return;

    //        int x = Random.Range(0, cardUpgrades.Count);
    //        int card1Assigned = x;

    //        GameObject card1 = Instantiate(cardPrefab, transform);
    //        card1.GetComponent<CardPrefab>().RetrieveCardInformation(cardUpgrades[x].upgradeName, cardUpgrades[x].upgradeLevel,
    //            cardUpgrades[x].upgradeDescription, cardUpgrades[x].cardType, cardUpgrades[x].cardStat);

    //        if (cardUpgrades.Count == 1) return;

    //        do
    //        {
    //            x = Random.Range(0, cardUpgrades.Count);
    //        }
    //        while (x == card1Assigned);

    //        int card2Assigned = x;

    //        GameObject card2 = Instantiate(cardPrefab, transform);
    //        card2.GetComponent<CardPrefab>().RetrieveCardInformation(cardUpgrades[x].upgradeName, cardUpgrades[x].upgradeLevel,
    //            cardUpgrades[x].upgradeDescription, cardUpgrades[x].cardType, cardUpgrades[x].cardStat);

    //        if (cardUpgrades.Count == 2) return;

    //        do
    //        {
    //            x = Random.Range(0, cardUpgrades.Count);
    //        }
    //        while (x == card1Assigned || x == card2Assigned);

    //        GameObject card3 = Instantiate(cardPrefab, transform);
    //        card3.GetComponent<CardPrefab>().RetrieveCardInformation(cardUpgrades[x].upgradeName, cardUpgrades[x].upgradeLevel,
    //            cardUpgrades[x].upgradeDescription, cardUpgrades[x].cardType, cardUpgrades[x].cardStat);
    //    }

    //    public void UpgradeSelected(CardStat _cardStat)
    //    {
    //        for(int i = 0; i < cardUpgrades.Count; i++)
    //        {
    //            if (cardUpgrades[i].cardStat == _cardStat)
    //            {
    //                if(cardUpgrades[i].cardType == CardType.Weapon && cardUpgrades[i].upgradeLevel == 0)
    //                {
    //                    weaponCounter++;
    //                }

    //                cardUpgrades[i].upgradeLevel++;
    //            }
    //        }
    //    }

    //    private void CardRemovalChecker()
    //    {
    //        for(int i = 0; i < cardUpgrades.Count; i++)
    //        {
    //            //removes extra weapons from list not selected
    //            if(weaponCounter >= 3)
    //                if (cardUpgrades[i].cardType == CardType.Weapon && cardUpgrades[i].upgradeLevel == 0)
    //                    cardUpgrades.RemoveAt(i--);            
    //        }

    //        for (int i = 0; i < cardUpgrades.Count; i++)
    //        {
    //            //checks if cards are level 5 or higher
    //            if (cardUpgrades[i].upgradeLevel >= 5)
    //                cardUpgrades.RemoveAt(i--);
    //        }
    //    }

    //    public void CreateNewCard(CardTemplate _cardTemplate)
    //    {
    //        cardUpgrades.Add(_cardTemplate);
    //    }

    //    public void RemoveCard(int _cardItemNum)
    //    {
    //        for(int i = 0; i < cardUpgrades.Count; i++)
    //        {
    //            if (cardUpgrades[i].cardItemNum == _cardItemNum)
    //                cardUpgrades.RemoveAt(i--);
    //        }
    //    }
}

[System.Serializable]
public class CardTemplate
{
    [Header("Card Details")]
    public string upgradeName;
    public int upgradeLevel = 0;
    public string upgradeDescription;
    public int cardItemNum;

    [Header("Card Enums")]
    public CardType cardType;
    public CardStat cardStat;

    public void UpgradeEffectList()
    {
        switch (cardStat)
        {
            case CardStat.MaxHealth:
                PlayerHealth.instance.RaiseMaxHealth(1);
                break;
        }

        upgradeLevel++;
    }
}

public enum CardStat
{
    MaxHealth,
    Damage,
    Defense,
    Speed,
    Cooldown,

    SpinningBaseballs,
    FlyingBats,
    AreaOfEffectWeapon,
    FrozenPopWeapon,
    BaseShooterWeapon
}
