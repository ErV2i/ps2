using UnityEngine;

public class tptotp : MonoBehaviour
{
    public GameObject objectToTp;
    public float delay = 1.0f;

    public GameObject tp1;
    public GameObject tp2;

    void Start()
    {
        Invoke("TeleportToTp1", delay);
    }

    void TeleportToTp1()
    {
        if (objectToTp != null && tp1 != null)
        {
            objectToTp.transform.position = tp1.transform.position;
            Invoke("TeleportToTp2", delay);
        }
    }

    void TeleportToTp2()
    {
        if (objectToTp != null && tp2 != null)
        {
            objectToTp.transform.position = tp2.transform.position;
        }
    }
}
