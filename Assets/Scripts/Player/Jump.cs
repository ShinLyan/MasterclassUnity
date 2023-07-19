using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight;
    [SerializeField, Range(0, 5)] private int maxAirJumps;
    [SerializeField, Range(0, 5f)] private float downwardMovementMultiplier;
    [SerializeField, Range(0, 5f)] private float upwardMovementMultiplier;

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    public int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;

    private Animator animator;

    public void ChangeMaxAirJumps(int delta)
    {
        maxAirJumps = Mathf.Min(maxAirJumps + delta, 5);
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        animator = GetComponent<Animator>();

        defaultGravityScale = 1f;
    }

    private void Update()
    {
        desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        if (onGround)
        {
            jumpPhase = 0;
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isJumping", false);
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if (body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;

    }


    private void JumpAction()
    {
        if (jumpPhase < maxAirJumps)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            animator.SetBool("isJumping", true);
            animator.SetBool("isAttacking", false);
            jumpPhase++;
            float jumpSpeed = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);

            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }
    }

    public void EndJumpBool() => animator.SetBool("isJumping", false);
    public void EndDoubleJumpBool() => animator.SetBool("isDoubleJumping", false);

}
