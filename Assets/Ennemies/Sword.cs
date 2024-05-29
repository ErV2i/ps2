using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private bool hasRotated = false;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        if (!hasRotated)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.rotation.eulerAngles.z - 90f) < 0.1f)
            {
                Destroy(gameObject);
                hasRotated = true;
            }
        }
    }
}
