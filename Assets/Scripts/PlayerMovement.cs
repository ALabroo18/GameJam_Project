using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 4.5f;

    private float horizontalInput;
    private float verticalInput;

    // Player component references.
    private Rigidbody2D rb2d;
    private Animator animator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        // Player movement in fixed update for accurate physics interactions.
        rb2d.velocity = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
    }

    private void PlayerInput()
    {
        horizontalInput = UserInput.instance.moveInput.x;
        verticalInput = UserInput.instance.moveInput.y;

        AnimationCheck();
    }

    // Changes the animation based on the direction the player is moving.
    private void AnimationCheck()
    {
        if (horizontalInput >= 0.1f)
        {
            // Moving right.
            ChangeAnimatorBools("MoveRight", "MoveLeft", "MoveUp", "MoveDown", "Idle");
        }
        else if (horizontalInput <= -0.1f)
        {
            // Moving left.
            ChangeAnimatorBools("MoveLeft", "MoveRight", "MoveUp", "MoveDown", "Idle");

        }
        else if (verticalInput >= 0.1f)
        {
            // Moving up.
            ChangeAnimatorBools("MoveUp", "MoveLeft", "MoveRight", "MoveDown", "Idle");

        }
        else if (verticalInput <= -0.1f)
        {
            // Moving down.
            ChangeAnimatorBools("MoveDown", "MoveLeft", "MoveUp", "MoveRight", "Idle");
        }
        else
        {
            // Not moving.
            ChangeAnimatorBools("Idle", "MoveLeft", "MoveUp", "MoveDown", "MoveRight");
        }
    }

    // Set all animator bools to false besides the one that should be true.
    private void ChangeAnimatorBools(string trueAnimBool, string falseAnimBool, string falseAnimBool2, string falseAnimBool3, string falseAnimBool4)
    {
        animator.SetBool(trueAnimBool, true);
        animator.SetBool(falseAnimBool, false);
        animator.SetBool(falseAnimBool2, false);
        animator.SetBool(falseAnimBool3, false);
        animator.SetBool(falseAnimBool4, false);
    }
}
