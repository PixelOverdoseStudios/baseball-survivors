using UnityEngine;

public class BallLauncherPrefab : MonoBehaviour
{
    private BallLauncherObject weapon;
    private Vector3 direction;

    private void Awake()
    {
        weapon = GetComponentInParent<BallLauncherObject>();
        Destroy(this.gameObject, 3f);
    }

    private void Start()
    {
        float angle = Mathf.Atan2(weapon.CheckForNearestTarget().transform.position.y - transform.position.y,
            weapon.CheckForNearestTarget().transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = targetRotation;

        direction = (weapon.CheckForNearestTarget().transform.position + new Vector3(0, 0.5f)) - transform.position;
        direction.Normalize();
    }

    private void Update()
    {
        transform.position += direction * weapon.projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(weapon.projectileDamage);
            Destroy(this.gameObject);
        }
    }
}
