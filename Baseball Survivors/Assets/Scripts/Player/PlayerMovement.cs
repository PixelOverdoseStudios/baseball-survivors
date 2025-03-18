using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [Header("Player Config")]
    [SerializeField] private float moveSpeed;

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
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovementLogic();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    #region Player Functions
    private void PlayerMovementLogic()
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
        if (PauseManager.instance.isPaused) return;

        moveInput = context.ReadValue<Vector2>();
    }
    #endregion
}
