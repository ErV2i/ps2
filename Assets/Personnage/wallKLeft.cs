using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallKLeft : MonoBehaviour

{
    private Rigidbody2D rb;
    private Quaternion initialRotation;
    private float initialGravityScale;
    private bool isWJumping;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(4f, 8f);
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
        return Physics2D.OverlapCircle(isWall.position, 0.2f, wallLayer);
    }

    private void WallJump()
    {
        wallJumpingCounter = wallJumpingTime;

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWJumping = true;
            rb.velocity = new Vector2(-wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            Invoke(nameof(StopWallJump), wallJumpingDuration);
        }
    }

    private void StopWallJump()
    {
        isWJumping = false;
    }

    private void Update()
    {
        if (IsWalled() && !isWJumping)
        {
            WallJump();
        }
    }
}

