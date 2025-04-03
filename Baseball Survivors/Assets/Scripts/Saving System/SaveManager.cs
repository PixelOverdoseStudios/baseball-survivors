using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [SerializeField] private string fileName;
    [SerializeField] private bool encryptData;

    private GameData gameData;
    private List<ISaveManager> saveManagers;
    private FileDataHandler dataHandler;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
        saveManagers = FindAllSaveManagers();

        LoadGame();
    }

    //private void Start()
    //{
    //    dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
    //    saveManagers = FindAllSaveManagers();

    //    LoadGame();
    //}

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();  
        }

        foreach(ISaveManager saveManager in saveManagers)
        {
            saveManager.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(ISaveManager saveManager in saveManagers)
        {
            saveManager.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    [ContextMenu("Delete save file")]
    public void DeleteSavedData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
        dataHandler.Delete();
    }

    private List<ISaveManager> FindAllSaveManagers()
    {
        IEnumerable<ISaveManager> saveManagers = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveManager>();

        return new List<ISaveManager>(saveManagers);
    }

    public bool HasSavedData()
    {
        if(dataHandler.Load() != null)
            return true;

        return false;
    }
}
