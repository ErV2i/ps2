using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantQuiTP : MonoBehaviour

{
    public float minDelay = 5f; 
    public float maxDelay = 10f;

    public GameObject[] teleportPoints;

    void Start()
    {
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            GameObject randomTeleportPoint = teleportPoints[Random.Range(0, teleportPoints.Length)]; // point tp au hasard

            transform.position = randomTeleportPoint.transform.position; //tp l'ennemies
        }
    }
}
