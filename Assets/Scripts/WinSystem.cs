using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.UI;

public class WinSystem : MonoBehaviour
{
    private List<Item> _Items = new List<Item>();
    private List<bool> _itemsInPlaceList = new List<bool>();

    [SerializeField]
    private RectTransform _panel;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _timeText;
    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private int _duration = 3;

    [Inject]
    private UIRayCast _uIRayCast;

    public bool IsAllComplite { get; private set; }

    public event SimpleHandle WinE;

    private void Start()
    {
        _uIRayCast.PutItemE += All—omposure—heck;
    }
    

    private void Win()
    {
        foreach (var item in _Items)
        {
            if (item == null) return;

            var pos = item.GetComponent<RectTransform>().anchoredPosition;
            item.GetComponent<RectTransform>().anchoredPosition = RandomPos();
            item.GetComponent<RectTransform>().DOAnchorPos(pos, _duration);
        }

        _winPanel.SetActive(true);
        WinE?.Invoke();
    }

    private Vector2 RandomPos()
    {
        var rX = Random.Range(_panel.offsetMin.x, _panel.offsetMax.x);
        var rY = Random.Range(_panel.offsetMin.y, _panel.offsetMax.y);

        return new Vector2(rX, rY);
    }

    public void All—omposure—heck()
    {
        _itemsInPlaceList.Clear();

        foreach (var item in _Items)
        {
            _itemsInPlaceList.Add(item.IsInPlace);
        }

        if (_itemsInPlaceList.Contains(false)) return;
        else Win();
    }

    #region SetMethids

    public void SetItems(Item item)
    {
        _Items.Add(item);
    }

    public void SetMoveCount(int count)
    {
        _scoreText.text = count.ToString();
    }

    public void SetTime(string time)
    {
        _timeText.text = time;
    }
#endregion SetMethids

    private void OnDestroy()
    {
        _uIRayCast.PutItemE -= All—omposure—heck;
    }
}
