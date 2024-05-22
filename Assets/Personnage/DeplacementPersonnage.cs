using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public int jumpPower = 10;
    bool grounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, 0f) * vitesseDeplacement * Time.deltaTime;
        transform.Translate(deplacement);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Sauter();
        }
    }

    void Sauter()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

  
}
