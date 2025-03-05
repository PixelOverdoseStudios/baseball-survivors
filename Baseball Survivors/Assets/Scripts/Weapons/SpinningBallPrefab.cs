using System.Collections;
using UnityEngine;

public class SpinningBallPrefab : MonoBehaviour
{
    private SpinningBallWeapon weapon;

    private float cooldownTimer;
    private Vector3 targetSize;
    private float rangeDistance;

    void Awake()
    {
        weapon = GetComponentInParent<SpinningBallWeapon>();
    }

    void Start()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
        transform.localScale = new Vector3(0f, 0f, 1f);    

        rangeDistance = weapon.range;
        targetSize = new Vector3(weapon.ballSize, weapon.ballSize, 1f);
    }

    private void Update()
    {
        //transform.up = Vector3.MoveTowards(transform.localScale, new Vector3(0, rangeDistance), weapon.distanceSpeed * Time.deltaTime);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, rangeDistance), weapon.distanceSpeed * Time.deltaTime);
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, weapon.growingSpeed * Time.deltaTime);

        cooldownTimer += Time.deltaTime;
        if(cooldownTimer > weapon.duration)
        {
            targetSize = Vector3.zero;
            rangeDistance = 0f;
            if(this.gameObject.transform.localScale.x <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(weapon.damage);
        }
    }
}
