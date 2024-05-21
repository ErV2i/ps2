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
        else
        {
            Debug.LogError("Pomme de terre a poeler lustucru ( changement de scene - SpawnPoint)");
        }
    }
}
