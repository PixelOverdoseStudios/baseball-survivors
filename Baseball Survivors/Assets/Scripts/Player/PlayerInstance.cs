using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance instance;

    [Header("Player Config")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Animators")]
    [SerializeField] private Animator bodyAnimator;
    [SerializeField] private Animator legsAnimator;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        if(moveInput != Vector2.zero)
        {
            legsAnimator.SetBool("moving", true);
        }
        else
        {
            legsAnimator.SetBool("moving", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        bodyAnimator.SetTrigger("attack");
    }
}
