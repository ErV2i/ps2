using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GenerateParticule();
    }

    private void GenerateParticule()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 spawnPosition = transform.position;

            Vector2 direction = Random.insideUnitCircle.normalized;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.velocity = direction * projectileSpeed;
        }
    }
}