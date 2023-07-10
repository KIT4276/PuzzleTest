using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void Again()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
