using UnityEngine;
using Zenject;

public class ChoosingPicture : MonoBehaviour
{
    [SerializeField]
    private GameObject _choosingDifficultyCanvas;

    [Inject]
    private DataHolder _dataHolder;

    private void Start()
    {
        _choosingDifficultyCanvas.SetActive(false);
    }

    public void SetPicture(int p)
    {
        _dataHolder.SetPicture(p);
        _choosingDifficultyCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
