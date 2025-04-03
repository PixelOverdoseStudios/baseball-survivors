using UnityEngine;
using UnityEngine.UI;

public class Test_MapButtonCollections : MonoBehaviour
{
    [SerializeField] private Button[] mapButtonList;

    private void Start()
    {
        mapButtonList[GameManager.instance.GetMapButtonIndex].GetComponent<Test_MapButton>().StartAsActiveButton();
    }

    public void DeactivateAllButtons()
    {
        for(int i = 0; i < mapButtonList.Length; i++)
        {
            mapButtonList[i].GetComponent<Test_MapButton>().DeactivateButton();
        }
    }
}
