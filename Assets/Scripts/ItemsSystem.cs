using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemsSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _frame;
    [SerializeField]
    private int _scatterDuration = 2;
    [SerializeField]
    private RectTransform _panel;
    [SerializeField]
    private List<Item> _Items = new List<Item>();
    [SerializeField]
    private List<RectTransform> _points = new List<RectTransform>();

    [Space, SerializeField]
    private RectTransform _box;

    [Inject]
    private UIRayCast _uIRayCast;
    [Inject]
    private WinSystem _winSystem;

    private void Start()
    {
        _winSystem.WinE += Win;

        foreach (var point in _points)
        {
            _uIRayCast.SetPoints(point);
        }

        ScatterPuzzles();

        _uIRayCast.SetCanvases(_panel);
        _uIRayCast.SetItemsRectTransform();
    }

    private Vector2 RandomPos()
    {
        var rX = Random.Range(_box.offsetMin.x, _box.offsetMax.x);
        var rY = Random.Range(_box.offsetMin.y, _box.offsetMax.y);

        return new Vector2(rX, rY);
    }

    private void Win()
    {
        _frame.SetActive(false);
        _winSystem.WinE -= Win;
    }

    public void ScatterPuzzles()
    {
        foreach (var item in _Items)
        {
            if (item == null) return;

            item.SetStartPos();
            _uIRayCast.SetItems(item);

            item.GetComponent<RectTransform>().DOAnchorPos(RandomPos(), _scatterDuration);
        }
    }
}
