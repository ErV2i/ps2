using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public GameObject Prefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GenerateParticle();
        GenerateItems();
    }

    private void GenerateParticle()
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

    private void GenerateItems()
{
    Vector3 spawnPosition = transform.position;
    Instantiate(Prefab, spawnPosition + (Vector3)(Random.insideUnitCircle * 2f), Quaternion.identity);
}
}