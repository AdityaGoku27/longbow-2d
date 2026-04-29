using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private PlayerControls controls;

    private Vector2 moveInput;
    private bool isGrounded;

    public Transform playerVisual;

    private Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = playerVisual.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (controls.Player.Jump.triggered && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveInput.x > 0)
        {
            playerVisual.localScale = new Vector3(1.7f,1.1f,1f);
        }
        else if (moveInput.x < 0)
        {
            playerVisual.localScale = new Vector3(-1.7f, 1.1f, 1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

}
