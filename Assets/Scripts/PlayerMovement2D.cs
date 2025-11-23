using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public enum PlayerId
    {
        Player1,
        Player2
    }

    [Header("Config")]
    public PlayerId playerId = PlayerId.Player1;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Movement Control")]
    public bool canMove = true;

    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;

    private float moveInput;
    [SerializeField] private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (!canMove) return;

        if (playerId == PlayerId.Player1)
        {
            moveInput = inputActions.Player.MoveP1.ReadValue<float>();

            if (inputActions.Player.JumpP1.triggered && IsGrounded())
            {
                Jump();
            }
        }
        else 
        {
            moveInput = inputActions.Player.MoveP2.ReadValue<float>();

            if (inputActions.Player.JumpP2.triggered && IsGrounded())
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return false;
        }

        Collider2D hit = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        isGrounded = (hit != null);
        return isGrounded;
    }

    public void DisableMovement()
    {
        canMove = false;
        rb.linearVelocity = Vector2.zero;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void Respawn(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        rb.linearVelocity = Vector2.zero;
        EnableMovement();
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
