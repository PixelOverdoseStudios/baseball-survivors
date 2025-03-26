using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private float spawnTime;
    private float spawnCounter;
    [SerializeField] private Transform[] spawnPoints;


    private void Update()
    {
        spawnCounter += Time.deltaTime;

        if(spawnCounter > spawnTime && PlayerHealth.instance.gameObject.activeInHierarchy)
        {
            SpawnEnemy();
            spawnCounter = 0;
        }
    }

    private void SpawnEnemy()
    {
        int spawnLocation = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyToSpawn, spawnPoints[spawnLocation].transform.position, Quaternion.identity);
    }
}
