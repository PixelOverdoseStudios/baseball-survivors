using System.Collections.Generic;
using UnityEngine;

public class BallLauncherObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesInSight;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private float cooldownTimer;
    private BallLauncherWeapon weapon;
    private Animator animator;

    [HideInInspector] public int projectileDamage;
    [HideInInspector] public float projectileSpeed;

    private bool isVisible;

    private void Awake()
    {
        weapon = FindFirstObjectByType<BallLauncherWeapon>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Destroy(this.gameObject, weapon.turretLifeTime);
        GetComponent<CircleCollider2D>().radius = weapon.detectionRadius;
        projectileDamage = Mathf.RoundToInt((weapon.damage[weapon.damageLevel] + GameManager.instance.GetDamageUpgrade()) * PlayerLevelingSystem.instance.damageMulti); ;
        projectileSpeed = weapon.projectileSpeed;
        cooldownTimer = weapon.fireRate[weapon.fireRateLevel] - 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInSight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInSight.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (enemiesInSight.Count == 0)
        {
            return;
        }
        else if (cooldownTimer > weapon.fireRate[weapon.fireRateLevel])
        {
            CheckForNearestTarget();
            AdjustFacingDirection();
            animator.SetTrigger("shoot");
            if(isVisible) AudioManager.instance.PlaySFXRandomPitch(2);
            cooldownTimer = 0;
        }
    }

    public void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.transform.position, Quaternion.identity, transform);
    }

    public GameObject CheckForNearestTarget()
    {
        GameObject closestObject = null;
        float smallestDistance = float.MaxValue;

        foreach (GameObject enemy in enemiesInSight)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closestObject = enemy;
            }
        }

        return closestObject;
    }

    private void AdjustFacingDirection()
    {
        Vector3 thisPosition = transform.position;
        Vector3 enemyPosition = CheckForNearestTarget().transform.position;

        float deltaX = thisPosition.x - enemyPosition.x;
        float deltaY = thisPosition.y - enemyPosition.y;

        if(Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX < 0) animator.SetTrigger("faceRight");
            if (deltaX > 0) animator.SetTrigger("faceLeft");
        }
        else
        {
            if (deltaY < 0) animator.SetTrigger("faceUp");
            if (deltaY > 0) animator.SetTrigger("faceDown");
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
    }
}
