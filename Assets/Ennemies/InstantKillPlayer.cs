using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKillPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision détecter");
            GetComponent<Restart>().RestartGame();
        }
    }
}