using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if(moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(moveInput.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        //if(moveInput != Vector2.zero)
        //{
        //    animator.SetBool("moving", true);
        //}
        //else
        //{
        //    animator.SetBool("moving", false);
        //}
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

        animator.SetTrigger("attack");
    }
}
