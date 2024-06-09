using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;

    private void Start()
    {
        virtualCam.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ActivateCamera();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }

    private void ActivateCamera()
    {
        Room[] rooms = FindObjectsOfType<Room>();
        foreach (Room room in rooms)
        {
            if (room.virtualCam != null && room.virtualCam != virtualCam)
            {
                room.virtualCam.SetActive(false);
            }
        }
        virtualCam.SetActive(true);
    }
}
