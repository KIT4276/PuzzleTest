using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MoveCounter : MonoBehaviour
{
    private int _movecount;

    [SerializeField]
    private Text text;
    
    [Inject]
    private UIRayCast _uIRayCast;
    [Inject]
    private WinSystem _winSystem;

    private void Start()
    {
        _uIRayCast.PutItemOnFrameE += Counter;
    }

    private void Counter()
    {
        _movecount++;
        text.text = _movecount.ToString();
        _winSystem.SetMoveCount(_movecount);
    }

    private void OnDestroy()
    {
        _uIRayCast.PutItemOnFrameE -= Counter;
    }
}
