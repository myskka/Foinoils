using UnityEngine;
using UnityEngine.SceneManagement;

public class Howtoplay : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
