using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance instance;

    [Header("Player Config")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackCooldown = 1f;
    private float attackTimer;

    [Header("Animators")]
    [SerializeField] private Animator bodyAnimator;
    [SerializeField] private Animator legsAnimator;

    [Header("Weapons")]
    [SerializeField] private GameObject basicAttack;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] private bool autoAttack;

    [SerializeField] private GameObject objectsToFlip;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();

        attackTimer += Time.deltaTime;
        if(autoAttack)
        {
            if(attackTimer > attackCooldown)
            {
                bodyAnimator.SetTrigger("attack");
                attackTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    #region Player Functions
    private void PlayerMovement()
    {
        if (moveInput.x > 0)
        {
            objectsToFlip.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            objectsToFlip.transform.localScale = Vector3.one;
        }

        if (moveInput != Vector2.zero)
        {
            bodyAnimator.SetBool("moving", true);
            legsAnimator.SetBool("moving", true);
        }
        else
        {
            bodyAnimator.SetBool("moving", false);
            legsAnimator.SetBool("moving", false);
        }
    }
    #endregion

    #region Input Actions
    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (autoAttack) return;

        if (attackTimer > attackCooldown)
        {
            bodyAnimator.SetTrigger("attack");
            attackTimer = 0;
        }
    }

    public void AutoAttackTrigger(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (autoAttack)
        {
            autoAttack = false;
        }
        else
        {
            autoAttack = true;
        }
    }
    #endregion
}
