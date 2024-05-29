using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    private GameObject atkArea = default;
    private bool atk = false;
    private float timer = 0f;
    private float timeToAttack = 0.25f;

    private void Start()
    {
        atkArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0));
        {
            Attack();
        }

        if (atk);
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                atk = false;
                atkArea.SetActive(atk);
            }
        }
    }
    private void Attack()
    {
        atk = true;
        atkArea.SetActive(atk);
    }
}
