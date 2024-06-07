using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("objet dans le trigger");
        if (other.CompareTag("Obstacle"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        } 
    }
}
