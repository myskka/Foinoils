using UnityEngine;
using UnityEngine.SceneManagement;

public class GDT_RestartScene : MonoBehaviour
{

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}