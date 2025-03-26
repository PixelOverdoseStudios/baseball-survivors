using UnityEngine;

public class FrozenPopPrefab : MonoBehaviour
{
    private FrozenPopsWeapon weapon;

    private int damageToGive;

    private void Awake()
    {
        weapon = FindFirstObjectByType<FrozenPopsWeapon>();
    }

    private void Start()
    {
        damageToGive = Mathf.RoundToInt((weapon.damage[weapon.damageLevel] + ShopStatUpgrades.instance.GetDamageUpgrade()) * PlayerLevelingSystem.instance.damageMulti);
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

        switch (tag)
        {
            case "Enemy":
                if(weapon.GetSpecialLevel() == 1 && other.GetComponent<EnemyBrain>().CanBeFrozen())
                {
                    int chance = Random.Range(1, 10);
                    if(chance == 1)
                    {
                        other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, weapon.slowDuration[weapon.slowDurationLevel], StatusEffect.frozen);
                    }
                    else
                    {
                        other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, weapon.slowDuration[weapon.slowDurationLevel], StatusEffect.slowed);
                    }
                }
                else if(weapon.GetSpecialLevel() == 2 && other.GetComponent<EnemyBrain>().CanBeFrozen())
                {
                    int chance = Random.Range(1, 10);
                    if (chance == 1 || chance == 2)
                    {
                        other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, weapon.slowDuration[weapon.slowDurationLevel], StatusEffect.frozen);
                    }
                    else
                    {
                        other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, weapon.slowDuration[weapon.slowDurationLevel], StatusEffect.slowed);
                    }
                }
                else
                {
                    other.GetComponent<EnemyHealth>().TakeDamage(damageToGive, weapon.slowDuration[weapon.slowDurationLevel], StatusEffect.slowed);
                }

                Destroy(this.gameObject);
                break;
            case "Fence":
                Destroy(this.gameObject);
                break;
        }
    }
}
