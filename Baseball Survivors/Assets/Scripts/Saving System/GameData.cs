using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency;
    public int activePlayerIndex;
    public int mapButtonIndex;
    public string mapSelectedToLoad;

    public GameData()
    {
        this.currency = 0;
        this.activePlayerIndex = 0;
        this.mapButtonIndex = 0;
        this.mapSelectedToLoad = "TestArena1";
    }
}
