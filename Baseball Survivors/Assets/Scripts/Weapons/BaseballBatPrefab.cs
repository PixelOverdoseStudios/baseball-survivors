using UnityEngine;

public class BaseballBatPrefab : MonoBehaviour
{
    private BaseballBatWeapon weapon;

    private void Awake()
    {
        weapon = FindFirstObjectByType<BaseballBatWeapon>();
    }

    private void Update()
    {
        transform.position += transform.up * weapon.projectileSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
