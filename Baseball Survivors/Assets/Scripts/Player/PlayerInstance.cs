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

    [Header("Weapons")]
    [SerializeField] private GameObject basicAttack;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] private GameObject objectsToFlip;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();
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
    #endregion
}
