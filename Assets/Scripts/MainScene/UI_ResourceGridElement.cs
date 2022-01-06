using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ResourceGridElement : MonoBehaviour
{
    // Items of element
    private Sprite _icon;
    private int _count;
    private string _name;

    // Item components
    [SerializeField] private Button _sellButton;
    [SerializeField] private SpriteRenderer _iconRenderer;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _countText;

    public void SetUpElement(Sprite icon , int count , string name)
    {
        _icon = icon;
        _count = count;
        _name = name;

        _nameText.text = _name;
        _countText.text = _count.ToString();
        //_iconRenderer.sprite = _icon;
        _iconImage.sprite = _icon;
        //_iconRenderer.

        _sellButton.onClick.AddListener(ClickedSellButton);

    }

    private void ClickedSellButton()
    {
        
    }
}
