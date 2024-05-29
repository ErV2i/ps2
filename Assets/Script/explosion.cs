using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public float minScale = 0.5f;
    public float maxScale = 2.0f;

    private void Start()
    {
        StartCoroutine(WaitAndGenerateParticles());
    }

    private IEnumerator WaitAndGenerateParticles()
    {
        yield return new WaitForSeconds(1f);
        GenerateParticule();
    }

    private void GenerateParticule()
    {
        Destroy(gameObject);
        for (int i = 0; i < 8; i++) 
        {
            Vector2 spawnPosition = transform.position;

            Vector2 direction = Random.insideUnitCircle.normalized;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            float randomScale = Random.Range(minScale, maxScale);
            projectile.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.velocity = direction * projectileSpeed;
        }
    }
}
