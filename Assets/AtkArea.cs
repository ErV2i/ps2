using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider>().GetComponent<Health>() != null) ;
        {
            health.Damage(damage);
        }
    }
}
