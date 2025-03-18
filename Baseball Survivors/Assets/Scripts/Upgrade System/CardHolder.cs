using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public static CardHolder instance;

    [SerializeField] private List<CardTemplateV2> availableCards;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public void AddCard(CardTemplateV2 _cardTemplate)
    {
        availableCards.Add(_cardTemplate);
    }

    public void RemoveCard(string _cardName)
    {
        for(int i =0; i < availableCards.Count; i++)
        {
            if (availableCards[i].cardName == _cardName)
            {
                availableCards.RemoveAt(i--);
            }
        }
    }

    public void RemoveCard(CardType _cardType)
    {
        for (int i = 0; i < availableCards.Count; i++)
        {
            if (availableCards[i].cardType == _cardType)
            {
                availableCards.RemoveAt(i--);
            }
        }
    }

    public void RemoveCard(CardEffect _cardEffect)
    {
        for (int i = 0; i < availableCards.Count; i++)
        {
            if (availableCards[i].cardEffect == _cardEffect)
            {
                availableCards.RemoveAt(i--);
            }
        }
    }

    public void RemoveOneCard(CardEffect _cardEffect)
    {
        for (int i = 0; i < availableCards.Count; i++)
        {
            if (availableCards[i].cardEffect == _cardEffect)
            {
                availableCards.RemoveAt(i--);
                return;
            }
        }
    }

    public List<CardTemplateV2> GetAvailableCards() { return availableCards; }
}
