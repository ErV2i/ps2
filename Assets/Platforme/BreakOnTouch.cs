using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnTouch : MonoBehaviour
{
    public GameObject DetruireObjet;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(DetruireObjet);
        }
    }
}