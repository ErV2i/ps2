using UnityEngine;

public class WallSlide : MonoBehaviour
{
    private Rigidbody2D rb;
    public float slideSpeed = 5f;
    private bool isSliding = false;
    private int slideDirection = 0; // 1 for down, -1 for up
    public float slideGravityScale = 1f;
    private Quaternion initialRotation;
    private float initialGravityScale;
    private bool isWallRight;

    private const string SlideTag = "Slide";
    private const string SlideRightTag = "SlideRight";

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
        if (other.gameObject.CompareTag(SlideTag))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            isSliding = true;
            rb.gravityScale = slideGravityScale;

            // Set slide direction
            slideDirection = -1; // Assuming sliding down
        }
        else if (other.gameObject.CompareTag(SlideRightTag))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            isSliding = true;
            rb.gravityScale = slideGravityScale;
            isWallRight = true;

            // Set slide direction
            slideDirection = -1; // Assuming sliding down
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(SlideTag) || other.gameObject.CompareTag(SlideRightTag))
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
        isSliding = false;
        slideDirection = 0;
        isWallRight = false;
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            Vector2 slideVelocity = new Vector2(0, slideDirection * slideSpeed);
            rb.velocity = slideVelocity;
        }
    }
}
