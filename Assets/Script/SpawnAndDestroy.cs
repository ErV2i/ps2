using UnityEngine;

public class SpawnAndDestroy : MonoBehaviour
{
    public GameObject LumPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnLum", 1f, 1f);
    }

    private void SpawnLum()
    {
        Vector3 parentPosition = transform.position;
        Vector3 spawnPosition = GetRandomOffset(parentPosition);
        GameObject lum = Instantiate(LumPrefab, spawnPosition, Quaternion.identity);
        Destroy(lum, 1f);
    }

    private Vector3 GetRandomOffset(Vector3 parentPosition)
    {
        float offsetX = Random.Range(-0.2f, 0.2f); 
        float offsetY = Random.Range(-0.2f, 0.2f);
        return parentPosition + new Vector3(offsetX, offsetY, 0.1f);
    }
}
