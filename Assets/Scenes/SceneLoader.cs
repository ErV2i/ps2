using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadScene(6);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            LoadScene(5);
        }
    }

    void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
