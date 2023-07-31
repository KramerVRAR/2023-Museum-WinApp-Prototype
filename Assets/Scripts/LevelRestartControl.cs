using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestartControl : MonoBehaviour
{
    public float restartTime = 30f; 
    private float lastInputTime; 

    private void Start()
    {
        lastInputTime = Time.time;
    }

    private void Update()
    {
        if (HasInput())
        {
            lastInputTime = Time.time;
        }
        else
        {
            if (Time.time - lastInputTime >= restartTime)
            {
                RestartLevel();
            }
        }
    }

    private bool HasInput()
    {
        return Input.anyKeyDown || Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
