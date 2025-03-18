using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu instance;

    [SerializeField] GameObject upgradeMenu;

    private void Awake()
    {
        UpgradeMenu.instance = this;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.G))
        //{
        //    if(upgradeMenu.activeSelf)
        //    {
        //        UpgradeMenuDeactivate();
        //    }
        //    else
        //    {
        //        UpgradeMenuActivate();
        //    }
        //}

        //while(upgradeMenu.activeSelf)
        //{
        //    Time.timeScale = 0;
        //}
    }

    public void UpgradeMenuActivate()
    {
        if(!upgradeMenu.activeSelf)
        {
            upgradeMenu.SetActive(true);
            PauseManager.instance.isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void UpgradeMenuDeactivate()
    {
        if(upgradeMenu.activeSelf)
        {
            upgradeMenu.SetActive(false);
            PauseManager.instance.isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
