using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarattaque : MonoBehaviour
{
    public GameObject epee;
    public Transform player;
    public GameObject targetObject;
    private Vector3 initialPosition;
    private bool playerDetected = false;
    private EnnemiesPatrol targetMovementScript;

    private void Start()
    {
        targetMovementScript = targetObject.GetComponent<EnnemiesPatrol>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            initialPosition = transform.position;
            Instantiate(epee);
            playerDetected = true;
            if (targetMovementScript != null)
            {
                targetMovementScript.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
            if (targetMovementScript != null)
            {
                targetMovementScript.enabled = true;
            }
        }
    }

    void Update()
    {
        if (playerDetected)
        {
            Debug.Log("Player détecté");
            transform.position = initialPosition;
        }
    }
}
