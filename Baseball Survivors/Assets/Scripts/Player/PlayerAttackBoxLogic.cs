using UnityEngine;

public class PlayerAttackBoxLogic : MonoBehaviour
{
    [SerializeField] private float attackRadius;

    private void OnEnable()
    {
        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        foreach (var hit in objectsHit)
        {
            if (hit.GetComponent<EnemyBrain>() != null)
            {
                Debug.Log("Enemy hit!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    //groundcast = Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 0f, Vector2.down, 1f, groundMask);
}
