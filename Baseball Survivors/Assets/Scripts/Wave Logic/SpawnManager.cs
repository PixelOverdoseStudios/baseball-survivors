using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Game Timer")]
    [SerializeField] private float gameTimer;
    private float minutes;
    private float seconds;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Spawn Locations")]
    [SerializeField] private List<Transform> spawnLocations;
    private float spawnTimer;

    [Header("Enemy List")]
    [SerializeField] private GameObject zombieEnemy;
    [SerializeField] private List<GameObject> enemyList;

    private void Update()
    {
        gameTimer += Time.deltaTime;
        UpdateTimer();
        SpawningEnemyWaveSystem();
    }

    private void UpdateTimer()
    {
        float min = Mathf.FloorToInt(gameTimer / 60f);
        float sec = Mathf.FloorToInt(gameTimer % 60f);
        timerText.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    private void SpawningEnemyWaveSystem()
    {
        spawnTimer += Time.deltaTime;

        if(gameTimer < 5f)
        {
            Debug.Log("First Wave");
            if(spawnTimer > 1)
            {
                int locationIndex = Random.Range(0, spawnLocations.Count);
                GameObject newEnemy = Instantiate(zombieEnemy, spawnLocations[locationIndex].transform.position, Quaternion.identity);
                enemyList.Add(newEnemy);

                spawnTimer = 0;
            }

        }
        else if(gameTimer < 20f)
        {
            Debug.Log("Second Wave");

            for(int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].GetComponent<EnemyBrain>().CheckIfOnScreen();
            }

            enemyList.Clear();
        }
        else
        {
            Debug.Log("Third Wave");
        }
    }
}
