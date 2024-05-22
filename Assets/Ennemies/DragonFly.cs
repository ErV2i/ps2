using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{
    public Transform Follow; 
    public float speed = 2f;
    public float Rayon = 5f; 
    public float maxDistance = 10f;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (Follow == null)
        {
            return;
        }

  
        Vector3 targetPosition = new Vector3(Follow.position.x, Follow.position.y + Rayon, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(transform.position, Follow.position);

        if (distanceToPlayer <= maxDistance)
        {
            Vector3 newPosition = new Vector3(Follow.position.x, Follow.position.y + maxDistance, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
    }
}
