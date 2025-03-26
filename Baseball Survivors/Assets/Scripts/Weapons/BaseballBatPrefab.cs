using UnityEngine;

public class BaseballBatPrefab : MonoBehaviour
{
    private BaseballBatWeapon weapon;
    private int damageToGive;

    private void Awake()
    {
        weapon = FindFirstObjectByType<BaseballBatWeapon>();
    }

    private void Start()
    {
        damageToGive = Mathf.RoundToInt((weapon.damage[weapon.damageLevel] + ShopStatUpgrades.instance.GetDamageUpgrade()) * PlayerLevelingSystem.instance.damageMulti);
        float projectileSize = weapon.projectileSize[weapon.projectileSizeLevel];
        transform.localScale = new Vector3(projectileSize, projectileSize, 1);
    }

    private void Update()
    {
        transform.position += transform.up * weapon.projectileSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        switch(tag)
        {
            case "Enemy":
                other.GetComponent<EnemyHealth>().TakeDamage(damageToGive);
                break;
            case "Fence":
                Destroy(this.gameObject);
                break;
        }
    }
}
