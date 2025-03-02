using UnityEngine;

public class EnemyHItBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            GetComponentInParent<PracticeDummyLogic>().TakeDamage();
        }
    }
}
