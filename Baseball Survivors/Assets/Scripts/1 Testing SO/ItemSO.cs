using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "CardTemplate")]
public class ItemSO : ScriptableObject
{
    public string upgradeName;
    public CardType cardType;
}
