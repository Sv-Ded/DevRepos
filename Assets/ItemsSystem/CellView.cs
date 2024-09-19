using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private Text _text;

    private Sprite _defaultSprite;
    private Image _itemIcon;

    private Cell _cell;

    private void Awake()
    {
        _text = GetComponent<Text>();


        _itemIcon = GetComponent<Image>();
        _defaultSprite = _itemIcon.sprite;
    }

    public void Init(Cell cell)
    {
        _cell = cell;
    }

    public void Render()
    {
        if (_cell.IsTaken)
        {
            _itemIcon.sprite = _cell.Item.ItemInfo.ItemIcon;

            _text.text = _cell.Item.ItemInfo.Name;
        }
        else
        {
            _itemIcon.sprite = _defaultSprite;
            _text.text = "";
        }
    }
}
