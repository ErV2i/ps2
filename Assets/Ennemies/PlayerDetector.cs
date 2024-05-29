using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public float detectionRadius = 5f;
    public Transform player;
    private Vector3 initialPosition;
    private bool playerDetected = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        DetectPlayer();

        if (!playerDetected)
        {
            initialPosition = transform.position;
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            transform.position = initialPosition;
            playerDetected = true;
            Debug.Log("Joueur détecté");

        }
        else
        {
            playerDetected = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}