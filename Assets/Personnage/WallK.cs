using UnityEngine;

public class WallK : MonoBehaviour
{
    private Rigidbody2D rb;
    private Quaternion initialRotation;
    private float initialGravityScale;
    private bool isWJumping;
    private float WallJumpDirection;
    private float wallJumpingTime = 0.2f;
    private float walluJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    [SerializeField] private Transform isWall;
    [SerializeField] private LayerMask wallLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            initialGravityScale = rb.gravityScale;
        }
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (rb != null)
            {
                rb.gravityScale = 0;
            }
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            ResetToInitialState();
        }
    }

    private void ResetToInitialState()
    {
        if (rb != null)
        {
            rb.gravityScale = initialGravityScale;
        }
        transform.rotation = initialRotation;
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(isWall.Position, 0.2f, wallLayer);
    }

    private void WallJump()
    {

    }
}
