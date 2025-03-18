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

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        switch(tag)
        {
            case "Enemy":
                other.GetComponent<EnemyHealth>().TakeDamage(weapon.damage);
                break;
            case "Fence":
                Destroy(this.gameObject);
                break;
        }
    }
}
