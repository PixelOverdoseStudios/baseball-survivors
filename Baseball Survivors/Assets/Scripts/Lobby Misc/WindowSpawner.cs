using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform spawnPoint;
    public Transform endPoint;

    [SerializeField] private float spawnTimer;
    private float spawnCounter;

    private void Start()
    {
        spawnCounter = spawnTimer - 3f;
    }

    private void Update()
    {
        spawnCounter += Time.deltaTime;

        if(spawnCounter >= spawnTimer)
        {
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity, this.transform);
            spawnCounter = 0;
        }
    }
}
