using UnityEngine;

public class FrozenPopPrefab : MonoBehaviour
{
    private FrozenPopsWeapon weapon;

    private void Awake()
    {
        weapon = FindFirstObjectByType<FrozenPopsWeapon>();
    }

    private void Update()
    {
        transform.position += transform.right * weapon.projectileSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        switch (tag)
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
