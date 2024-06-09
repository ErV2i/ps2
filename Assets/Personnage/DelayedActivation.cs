using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    public float delay = 1.0f;

    void Start()
    {
        objectToActivate.SetActive(false);
        Invoke("ActivateObject", delay);
    }

    void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}
