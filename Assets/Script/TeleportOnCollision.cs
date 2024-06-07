using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Un objet est entré dans le trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision détectée avec le Player");
            other.transform.position = teleportPoint.position;
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            Debug.Log("Collision avec un objet non-Player: " + other.tag);
        }
    }
}
