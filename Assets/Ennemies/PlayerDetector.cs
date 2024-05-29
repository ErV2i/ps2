using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public float detectionRadius = 5f;
    public Transform player;
    public GameObject epee;
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

            GeneratePrefab();
        }
        else
        {
            playerDetected = false;
        }
    }

    void GeneratePrefab()
    {
        if (epee != null)
        {
            Instantiate(epee, transform.position, Quaternion.identity);
            Debug.Log("Prefab généré");
        }
        else
        {
            Debug.LogWarning("Object pas la");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}