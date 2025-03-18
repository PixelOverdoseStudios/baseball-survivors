using UnityEngine;

public class FrozenPopsWeapon : MonoBehaviour
{
    [SerializeField] private GameObject frozenPopPrefab;
    [SerializeField] private float weaponCooldown;
    private float cooldownCounter;
    private int spawnPosition;
    public int damage;
    public int projectileSpeed;

    private void Update()
    {
        cooldownCounter += Time.deltaTime;

        if(cooldownCounter >= weaponCooldown)
        {
            ShootPrefab();
            cooldownCounter = 0;
        }
    }

    private void ShootPrefab()
    {
        float degreeChange;

        switch(spawnPosition)
        {
            case 0:
                degreeChange = 135f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 1:
                degreeChange = 90f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 2:
                degreeChange = 45f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 3:
                degreeChange = 0f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 4:
                degreeChange = 315f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 5:
                degreeChange = 270f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 6:
                degreeChange = 225f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
            case 7:
                degreeChange = 180f;
                transform.rotation = Quaternion.Euler(0, 0, degreeChange);
                Instantiate(frozenPopPrefab, transform.position, transform.rotation);
                UpdateSpawnPosition();
                break;
        }
    }

    private void UpdateSpawnPosition()
    {
        spawnPosition++;
        if(spawnPosition >= 8) spawnPosition = 0;
    }
}
