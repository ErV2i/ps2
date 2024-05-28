
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesPatrol : MonoBehaviour
{
    public float vitesse;
    public Transform[] point;

    private Transform targ;
    private int adestPoint = 0;

   private void Start()
    {
        targ = point[0];
    }

    private void Update()
    {
        Vector3 dir = targ.position - transform.position;
        transform.Translate(dir.normalized * vitesse * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, targ.position) < 0.3f)
        {
            adestPoint = (adestPoint + 1) % point.Length;
            targ = point[adestPoint];

            Flip();
        }
    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}