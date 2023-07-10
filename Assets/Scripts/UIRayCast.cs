using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIRayCast : MonoBehaviour
{
    private RectTransform _selectedItem;
    private List<RectTransform> _itemsRectTransform = new List<RectTransform>();
    private List<RectTransform> _points = new List<RectTransform>();
    private List<Item> _items = new List<Item>();
    private RectTransform _panel;
    private Vector2 _offset;

    [SerializeField]
    private InputAction _input;

    public bool IsStarted { get; private set; }

    public event SimpleHandle PutItemE;
    public event SimpleHandle PutItemOnFrameE;

    private void Start()
    {
        _input.Enable();

        _input.performed += _ => OnClick(true);
        _input.canceled += _ => OnClick(false);
    }

    private void Update()
    {
        if(IsStarted) 
            ShiftingItem();
    }

    private void ShiftingItem()
    {
        if (_selectedItem == null) return;

        var pos = Mouse.current.position.ReadValue();

        _selectedItem.anchoredPosition = pos + _offset;
    }

    private void OnClick(bool isDown)
    {
        var pos = Mouse.current.position.ReadValue();

        if (!isDown) 
        {
            foreach (var point in _points)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(point, pos))
                {
                    _selectedItem.anchoredPosition = point.anchoredPosition;
                   _selectedItem.GetComponent<Item>().—omposure—heck();

                    PutItemOnFrameE?.Invoke();
                }
            }
            _selectedItem = null;

            PutItemE?.Invoke();
            return;
        }

        if (!RectTransformUtility.RectangleContainsScreenPoint(_panel, pos)) return;

        foreach (var item in _itemsRectTransform)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(item, pos))
            {
                _selectedItem = item;
                _offset = _selectedItem.anchoredPosition - pos;
                return;
            }
        }
    }

    #region SetMethods

    public void SetItems(Item item)
    {
        _items.Add(item);
    }

    public void SetPoints(RectTransform point)
    {
        _points.Add(point);
    }

    public void SetCanvases( RectTransform panel)
    {
        _panel = panel;
    }

    public void SetItemsRectTransform()
    {
        foreach (var item in _items)
        {
            _itemsRectTransform.Add(item.GetComponent<RectTransform>());
        }

        IsStarted = true;
    }

    #endregion SetMethods
}
