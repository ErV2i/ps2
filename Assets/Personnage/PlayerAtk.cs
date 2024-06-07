using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public GameObject atkAreaObject;
    private AtkArea atkArea;
    private bool atk = false;
    private float timer = 0f;
    private float timeToAttack = 0.25f;

    private void Start()
    {
        atkArea = atkAreaObject.GetComponent<AtkArea>();
        atkArea.gameObject.SetActive(false);
        Debug.Log("Start: atkArea is set to inactive");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }

        if (atk)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                atk = false;
                atkArea.isAttacking = false;
                atkArea.gameObject.SetActive(false);
                Debug.Log("Update: Attack duration ended, atkArea set to inactive");
            }
        }
    }

    private void Attack()
    {
        atk = true;
        atkArea.isAttacking = true;
        atkArea.gameObject.SetActive(true);
        Debug.Log("Attack: atkArea set to active");
    }
}
