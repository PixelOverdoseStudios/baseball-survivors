using System.Collections;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool canKnockback;
    [SerializeField] private float knockBackDuration = 0.2f;

    private Rigidbody2D rb;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = (PlayerInstance.instance.transform.position - transform.position).normalized;

        if(PlayerInstance.instance.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    private void FixedUpdate()
    {
        if(PlayerInstance.instance.gameObject.activeSelf && Vector3.Distance(transform.position, PlayerInstance.instance.transform.position) > 0.1f)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public IEnumerator KnockBackCo()
    {
        moveSpeed *= -1;
        yield return new WaitForSeconds(knockBackDuration);
        moveSpeed *= -1;
    }
}
