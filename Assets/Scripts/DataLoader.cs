using UnityEngine;
using Zenject;

public class DataLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject _1_4x4;
    [SerializeField]
    private GameObject _1_5x5;
    [SerializeField]
    private GameObject _1_6x6;

    [Space, SerializeField]
    private GameObject _2_4x4;
    [SerializeField]
    private GameObject _2_5x5;
    [SerializeField]
    private GameObject _2_6x6;

    [Inject]
    private DataHolder _dataHolder;

    private void Start()
    {
        if(_dataHolder.GetPicture() == 1)
        {
            switch (_dataHolder.GetDifficulty())
            {
                case 4:
                    _1_4x4.SetActive(true);
                    break;
                case 5:
                    _1_5x5.SetActive(true);
                    break;
                case 6:
                    _1_6x6.SetActive(true);
                    break;
            }
        }
        else if(_dataHolder.GetPicture() == 2)
        {
            switch (_dataHolder.GetDifficulty())
            {
                case 4:
                    _2_4x4.SetActive(true);
                    break;
                case 5:
                    _2_5x5.SetActive(true);
                    break;
                case 6:
                    _2_6x6.SetActive(true);
                    break;
            }
        }
    }
}
