using UnityEngine;

public class TestingAddingCard : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CardTemplateV2 testingCard = new CardTemplateV2();
            testingCard.cardName = "Testing Title";
            testingCard.cardDescription = "Example of a description text";

            CardHolder.instance.AddCard(testingCard);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            CardHolder.instance.RemoveCard("Testing Title");
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G was pressed");

            if(levelUpPanel.activeSelf)
            {
                levelUpPanel.SetActive(false);
            }
            else
            {
                levelUpPanel.SetActive(true);
            }
        }
    }
}
