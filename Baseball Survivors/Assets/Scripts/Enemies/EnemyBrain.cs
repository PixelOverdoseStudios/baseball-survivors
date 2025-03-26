using System.Collections;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [Header("Defaults")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool canKnockback;
    private float knockBackDuration = 0.2f;
    [SerializeField] private bool canBeFrozen;
    [SerializeField] private GameObject iceSprite;

    [Header("Conditionals")]
    [SerializeField] private bool isBeingKnockedBack;
    [SerializeField] private bool isSlowed;
    [SerializeField] private bool isFrozen;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private Vector3 moveDirection;
    [SerializeField] private float slowedTime;
    private float slowedCounter;
    private float frozenCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveDirection = (PlayerMovement.instance.transform.position - transform.position).normalized;

        if(!isFrozen)
        {
            if(PlayerMovement.instance.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
        

        if (slowedCounter > 0) slowedCounter -= Time.deltaTime;
        else if (slowedCounter < 0)
        {
            isSlowed = false;
            CheckColorSprite();
        }

        if (frozenCounter > 0) frozenCounter -= Time.deltaTime;
        else if (frozenCounter < 0)
        {
            isFrozen = false;
            if (iceSprite.activeInHierarchy) iceSprite.SetActive(false);
            animator.speed = 1;
            CheckColorSprite();
        }
    }

    private void FixedUpdate()
    {
        if(PlayerMovement.instance.gameObject.activeSelf && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > 0.1f
            && !isSlowed && !isFrozen || isBeingKnockedBack)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else if (PlayerMovement.instance.gameObject.activeSelf && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > 0.1f
            && isSlowed && !isBeingKnockedBack && !isFrozen)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * (moveSpeed / 2f), moveDirection.y * (moveSpeed / 2f));
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
        isBeingKnockedBack = true;
        float originalMoveSpeed = moveSpeed;
        moveSpeed = -knockBackForce;
        yield return new WaitForSeconds(knockBackDuration);
        moveSpeed = originalMoveSpeed;
        isBeingKnockedBack = false;
    }

    public void EnemyIsSlowed(float timeOfEffect)
    {
        isSlowed = true;
        slowedCounter = timeOfEffect;
        CheckColorSprite();
    }

    public void EnemyIsFrozen(float timeOfEffect)
    {
        isFrozen = true;
        if(!iceSprite.activeInHierarchy) iceSprite.SetActive(true);
        animator.speed = 0;
        frozenCounter = timeOfEffect;
        CheckColorSprite();
    }

    public bool CanBeFrozen() => canBeFrozen;
    public bool IsFrozen() => isFrozen;

    public void CheckColorSprite()
    {
        if(isSlowed || isFrozen)
        {
            sr.color = Color.blue;
        }
        else
        {
            sr.color = Color.white;
        }
    }
}
