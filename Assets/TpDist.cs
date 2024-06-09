using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpDist : MonoBehaviour
{
    public GameObject ZoneTP;
    public GameObject ObjectToTP;
    public GameObject Player;
    public GameObject TpHere;
      
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == Player)
        {
            if (ObjectToTP != null && TpHere != null)
            {
                ObjectToTP.transform.position = TpHere.transform.position;
            }
        }
    }
}
