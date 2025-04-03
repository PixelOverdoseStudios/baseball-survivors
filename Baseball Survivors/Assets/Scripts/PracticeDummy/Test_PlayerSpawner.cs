using UnityEngine;

public class Test_PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        Instantiate(GameManager.instance.GetActivePlayerObject, spawnPoint.transform.position, Quaternion.identity);
    }
}
