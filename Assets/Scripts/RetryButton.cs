using UnityEngine.SceneManagement;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void replayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
