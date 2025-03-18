using UnityEngine;

public class SpinningBallWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject baseballPrefab;
    public float distanceSpeed;
    public float growingSpeed;

    [Header("Stats")]
    [SerializeField] [Range(1, 3)] private int numberOfBalls = 1;
    public int damage;
    public float rotationSpeed;
    public float range;
    public float ballSize;
    public float duration;
    public float weaponCooldown;

    private float cooldownCounter;

    [Header("Spawning Locations")]
    [SerializeField] private Transform degree0SpawnPoint;
    [SerializeField] private Transform degree120SpawnPoint;
    [SerializeField] private Transform degree180SpawnPoint;
    [SerializeField] private Transform degree240SpawnPoint;

    private void Start()
    {
        cooldownCounter = weaponCooldown - 0.5f;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

        cooldownCounter += Time.deltaTime;
        if(cooldownCounter >= weaponCooldown)
        {
            switch(numberOfBalls)
            {
                case 1:
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation, 
                        degree0SpawnPoint.transform);
                    break;
                case 2:
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation,
                        degree0SpawnPoint.transform);                    
                    Instantiate(baseballPrefab, transform.position, degree0SpawnPoint.transform.rotation,
                        degree180SpawnPoint.transform);
                    break;
                case 3:
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree0SpawnPoint.transform);
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree120SpawnPoint.transform);
                    Instantiate(baseballPrefab, transform.position, transform.rotation,
                        degree240SpawnPoint.transform);
                    break;
            }
            cooldownCounter = 0;
        }
    }
}
