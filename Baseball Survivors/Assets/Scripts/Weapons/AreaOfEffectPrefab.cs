using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectPrefab : MonoBehaviour
{
    [SerializeField] private GameObject effectSpecial;

    public List<GameObject> enemiesInRange;

    private AreaOfEffectWeapon weapon;
    private Vector3 startPosition = Vector3.zero;
    private float elapsedTime;
    private float damagerCounter;
    private float growthTimer;
    private float shrinkTimer;
    private int damageToGive;

    private void Awake()
    {
        weapon = GetComponentInParent<AreaOfEffectWeapon>();
    }

    private void Start()
    {
        transform.localScale = startPosition;
        damageToGive = Mathf.RoundToInt((weapon.damage[weapon.damageLevel] + GameManager.instance.GetDamageUpgrade()) * PlayerLevelingSystem.instance.damageMulti);
        if(effectSpecial.activeInHierarchy) effectSpecial.SetActive(false);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime < weapon.duration)
        {
            GrowCircle();
        }
        else
            ShrinkCircle();

        damagerCounter += Time.deltaTime;
        if(damagerCounter >= weapon.timeBetweenDamage)
        {
            if (enemiesInRange.Count > 0)
            {
                if(weapon.SpecialLevel() == 1)
                {
                    int chance = Random.Range(1, 20);

                    if(chance == 1)
                    {
                        for (int i = 0; i < enemiesInRange.Count; i++)
                        {
                            if (enemiesInRange[i] != null)
                            {
                                enemiesInRange[i].GetComponent<EnemyHealth>().
                                    TakeDamage(damageToGive, weapon.specialKnockBackForce);
                            }
                        }
                        effectSpecial.SetActive(true);
                    }
                    else
                    {
                        for (int i = 0; i < enemiesInRange.Count; i++)
                        {
                            if (enemiesInRange[i] != null)
                            {
                                enemiesInRange[i].GetComponent<EnemyHealth>().
                                    TakeDamage(damageToGive);
                            }
                        }
                    }
                }
                else if(weapon.SpecialLevel() == 2)
                {
                    int chance = Random.Range(1, 20);

                    if(chance == 1 || chance == 2)
                    {
                        for (int i = 0; i < enemiesInRange.Count; i++)
                        {
                            if (enemiesInRange[i] != null)
                            {
                                enemiesInRange[i].GetComponent<EnemyHealth>().
                                    TakeDamage(damageToGive, weapon.specialKnockBackForce);
                            }
                        }
                        effectSpecial.SetActive(true);
                    }
                    else
                    {
                        for (int i = 0; i < enemiesInRange.Count; i++)
                        {
                            if (enemiesInRange[i] != null)
                            {
                                enemiesInRange[i].GetComponent<EnemyHealth>().
                                    TakeDamage(damageToGive);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < enemiesInRange.Count; i++)
                    {
                        if (enemiesInRange[i] != null)
                        {
                            enemiesInRange[i].GetComponent<EnemyHealth>().
                                TakeDamage(damageToGive);
                        }
                    }
                }
            }
            damagerCounter = 0;
        }
    }

    private void GrowCircle()
    {
        growthTimer += Time.deltaTime;
        float percentageComplete = growthTimer / 0.5f;
        transform.localScale = Vector3.Lerp(startPosition, new Vector3(weapon.targetSize[weapon.radiusLevel], weapon.targetSize[weapon.radiusLevel], 1f), percentageComplete);
    }

    private void ShrinkCircle()
    {
        shrinkTimer += Time.deltaTime;
        float percentageComplete = shrinkTimer / 0.5f;
        transform.localScale = Vector3.Lerp(new Vector3(weapon.targetSize[weapon.radiusLevel], weapon.targetSize[weapon.radiusLevel], 1f), Vector3.zero, percentageComplete);
        if(transform.localScale.x <= 0f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
