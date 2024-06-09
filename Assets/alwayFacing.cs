using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFacing : MonoBehaviour
{
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FlipTowardsPlayer();
    }

    void FlipTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 scale = transform.localScale;
            if (player.transform.position.x < transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            else
            {
                scale.x = -Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }
    }
}
