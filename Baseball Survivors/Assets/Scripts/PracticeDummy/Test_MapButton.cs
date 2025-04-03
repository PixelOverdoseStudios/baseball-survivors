using UnityEngine;

public class Test_MapButton : MonoBehaviour
{
    [SerializeField] private string mapToLoad;
    [SerializeField] private int mapIndex;
    [SerializeField] private GameObject border;

    private Test_MapButtonCollections mapCollections;

    private void Awake()
    {
        mapCollections = GetComponentInParent<Test_MapButtonCollections>();
    }

    public void StartAsActiveButton()
    {
        border.SetActive(true);
    }

    public void DeactivateButton()
    {
        border.SetActive(false);
    }

    public void WhenPressed()
    {
        mapCollections.DeactivateAllButtons();
        border.SetActive(true);
        GameManager.instance.ChangeMapToLoad(mapToLoad);
        GameManager.instance.ChangeMapButtonIndex(mapIndex);
    }
}
