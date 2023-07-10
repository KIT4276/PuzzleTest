using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ChoosingDifficulty : MonoBehaviour
{
    [Inject]
    private DataHolder _dataHolder;

    public void SetDifficulty(int d)
    {
        _dataHolder.SetDifficulty(d);
        this.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(1);
    }
}
