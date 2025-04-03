using System.Collections;
using UnityEngine;

public class SpinningBallPrefab : MonoBehaviour
{
    private SpinningBallWeapon weapon;

    private Vector3 targetSize;
    private float rangeDistance;
    private int damageToGive;

    private Vector3 startPosition;
    private Vector3 startSize = new Vector3(0f, 0f, 1f);

    private float elapsedTime;
    private float growthTimer;
    private float shrinkTimer;

    void Awake()
    {
        weapon = GetComponentInParent<SpinningBallWeapon>();
    }

    void Start()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 300f);
        transform.localScale = startSize;    

        transform.localPosition = startPosition;
        rangeDistance = weapon.range;
        targetSize = new Vector3(weapon.ballSize, weapon.ballSize, 1f);
        damageToGive = Mathf.RoundToInt((weapon.damage[weapon.damageLevel] + GameManager.instance.GetDamageUpgrade()) * PlayerLevelingSystem.instance.damageMulti);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime < weapon.duration)
        {
            StartWeaponCycle();
        }
        else
        {
            EndWeaponCycle();
        }
    }

    private void StartWeaponCycle()
    {
        growthTimer += Time.deltaTime;
        float percentageComplete = growthTimer / 0.5f;

        transform.localPosition = Vector3.Lerp(startPosition, new Vector3(rangeDistance, rangeDistance, 1), percentageComplete);
        transform.localScale = Vector3.Lerp(startSize, targetSize, percentageComplete);
    }

    private void EndWeaponCycle()
    {
        shrinkTimer += Time.deltaTime;
        float percentageComplete = shrinkTimer / 20f;
        Vector3 currentPosition = transform.localPosition;
        Vector3 currentSize = transform.localScale;

        transform.localPosition = Vector3.Lerp(currentPosition, Vector3.zero, percentageComplete);
        transform.localScale = Vector3.Lerp(currentSize, Vector3.zero, percentageComplete);
        if (transform.localScale.x <= 0f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageToGive);
        }
    }
}
