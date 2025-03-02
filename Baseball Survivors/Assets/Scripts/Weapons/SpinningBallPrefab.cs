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
}
