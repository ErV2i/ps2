using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpOnPosBalle : MonoBehaviour
{
    private Transform teleportPoint;

    private void Awake()
    {
        GameObject tp1Object = GameObject.FindGameObjectWithTag("tp1");
        if (tp1Object != null)
        {
            teleportPoint = tp1Object.transform;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            if (teleportPoint != null)
            {
                other.transform.position = teleportPoint.position;
                Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.velocity = Vector2.zero;
                }
            }

        }
    }
}
