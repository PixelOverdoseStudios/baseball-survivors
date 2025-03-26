using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private List<CardTemplateV2> retrievedCardList;

    private void OnEnable()
    {
        DisplayCardOptions();
    }

    private void OnDisable()
    {
        PauseManager.instance.CheckPauseState();
    }

    private void DisplayCardOptions()
    {
        retrievedCardList = CardHolder.instance.GetAvailableCards();

        if (retrievedCardList.Count == 0) return;

        int x = Random.Range(0, retrievedCardList.Count);
        int card1Assigned = x;

        GameObject card1 = Instantiate(cardPrefab, transform);
        card1.GetComponent<CardPrefab>().RetrieveData(retrievedCardList[x].cardImage, retrievedCardList[x].cardName, retrievedCardList[x].cardType, retrievedCardList[x].cardEffect, retrievedCardList[x].cardDescription);

        if (retrievedCardList.Count == 1) return;

        do
        {
            x = Random.Range(0, retrievedCardList.Count);
        }
        while(x == card1Assigned);
        int card2Assigned = x;

        GameObject card2 = Instantiate(cardPrefab, transform);
        card2.GetComponent<CardPrefab>().RetrieveData(retrievedCardList[x].cardImage, retrievedCardList[x].cardName, retrievedCardList[x].cardType, retrievedCardList[x].cardEffect, retrievedCardList[x].cardDescription);

        if (retrievedCardList.Count == 2) return;

        do
        {
            x = Random.Range(0, retrievedCardList.Count);
        }
        while (x == card1Assigned || x == card2Assigned);

        GameObject card3 = Instantiate(cardPrefab, transform);
        card3.GetComponent<CardPrefab>().RetrieveData(retrievedCardList[x].cardImage, retrievedCardList[x].cardName, retrievedCardList[x].cardType, retrievedCardList[x].cardEffect, retrievedCardList[x].cardDescription);
    }
}
