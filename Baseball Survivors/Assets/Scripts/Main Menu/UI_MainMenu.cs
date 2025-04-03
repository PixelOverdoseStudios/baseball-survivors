using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string loungeScene;
    [SerializeField] private GameObject continueButton;

    private void Start()
    {
        if (SaveManager.instance.HasSavedData() == false)
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        //else
        //{
        //    continueButton.GetComponent<Button>().interactable = true;
        //}
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(loungeScene);
    }

    public void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        SceneManager.LoadScene(loungeScene);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
    }
}
