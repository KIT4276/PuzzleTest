using UnityEngine;
using Zenject;

public class Item : MonoBehaviour
{
    private Vector2 _startPos;

    [Inject]
    private WinSystem _winSystem;

    public bool IsInPlace { get; private set; }

    private void Start()
    {
        _winSystem.SetItems(this);
    }

    public void —omposure—heck()
    {
        if (GetComponent<RectTransform>().anchoredPosition == _startPos)
        {
            IsInPlace = true;
        }
        else
        {
            IsInPlace = false;
        }
    }

    public void SetStartPos()
    {
        _startPos = GetComponent<RectTransform>().anchoredPosition;
    }
}
