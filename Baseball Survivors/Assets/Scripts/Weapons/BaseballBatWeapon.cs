using UnityEngine;

public class BaseballBatWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject baseballBatPrefab;

    [Header("Stats")]
    [SerializeField][Range(1, 3)] private int weaponLevel = 1;
    public float projectileSpeed;
    public float projectileSize;
    public float weaponCooldown;

    private float cooldownCounter;
    private float positionTracker = 0;



    private void Update()
    {
        cooldownCounter += Time.deltaTime;

        if (cooldownCounter >= weaponCooldown)
        {
            switch (weaponLevel)
            {
                case 1:
                    switch (positionTracker)
                    {
                        case 0:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                            positionTracker++;
                            break;
                        case 1:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                            positionTracker++;
                            break;
                        case 2:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                            positionTracker++;
                            break;
                        case 3:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                            positionTracker = 0;
                            break;
                    }
                    cooldownCounter = 0;
                    break;
                case 2:
                    switch (positionTracker)
                    {
                        case 0:
                        case 2:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                            positionTracker++;
                            break;
                        case 1:
                        case 3:
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                            Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                            positionTracker++;
                            if (positionTracker == 4) positionTracker = 0;
                            break;
                    }
                    cooldownCounter = 0;
                    break;
                case 3:
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
                    cooldownCounter = 0;
                    break;
            }
        }


        //if(cooldownCounter >= weaponCooldown)
        //{
        //    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
        //    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
        //    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
        //    Instantiate(baseballBatPrefab, transform.position, Quaternion.Euler(0f, 0f, 270f));
            
        //    cooldownCounter = 0;
        //}
    }
}
