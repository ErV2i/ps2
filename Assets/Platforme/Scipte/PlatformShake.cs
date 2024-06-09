using System.Collections;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public GameObject targetObject;
    public float fallDistance = 0.5f;
    public float fallDuration = 0.5f;
    public float returnDuration = 0.5f; 

    private Vector3 initialPosition;
    private bool isFalling = false;

    private void Start()
    {
        if (targetObject != null)
        {
            initialPosition = targetObject.transform.localPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(FallAndReturn());
        }
    }

    private IEnumerator FallAndReturn()
    {
        isFalling = true;
        Vector3 fallPosition = initialPosition + Vector3.down * fallDistance;
        float elapsedTime = 0f; 

        while (elapsedTime < fallDuration)
        {
            targetObject.transform.localPosition = Vector3.Lerp(initialPosition, fallPosition, elapsedTime / fallDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.localPosition = fallPosition;

        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0f;

        while (elapsedTime < returnDuration)
        {
            targetObject.transform.localPosition = Vector3.Lerp(fallPosition, initialPosition, elapsedTime / returnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.localPosition = initialPosition;

        isFalling = false;
    }
}
