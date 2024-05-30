using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkArea : MonoBehaviour
{
    public int damage = 3;
    public bool isAttacking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking)
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
                Debug.Log("AtkArea, dégat à " + collision.gameObject.name);
            }
        }
    }
}
