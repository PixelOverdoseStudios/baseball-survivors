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
        moveDirection = (PlayerMovement.instance.transform.position - transform.position).normalized;

        if(PlayerMovement.instance.transform.position.x > transform.position.x)
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
        if(PlayerMovement.instance.gameObject.activeSelf && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > 0.1f)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public void CanKnockBackCheck(float _knockBackForce)
    {
        if (!canKnockback) return;

        StartCoroutine(KnockBackCo(_knockBackForce));
    }

    private IEnumerator KnockBackCo(float knockBackForce)
    {
        float originalMoveSpeed = moveSpeed;
        moveSpeed = -knockBackForce;
        yield return new WaitForSeconds(knockBackDuration);
        moveSpeed = originalMoveSpeed;
    }
}
