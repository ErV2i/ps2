using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject monPersoSpawn;

    private void Awake()
    {
        monPersoSpawn = GameObject.FindGameObjectWithTag("Player");

        if (monPersoSpawn != null)
        {
            monPersoSpawn.transform.position = transform.position;
        }

    }
}
