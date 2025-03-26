using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject levelUpPanel;
    [HideInInspector] public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    public void ForcePause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ForceUnpause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CheckPauseState()
    {
        if(levelUpPanel.gameObject.activeSelf || pauseMenu.gameObject.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
    }

    public void PauseAndUnpause(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (!pauseMenu.activeSelf)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
