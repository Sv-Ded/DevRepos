using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Text _text;
    private string _defaultText = "";

    private Sprite _defaultSprite;
    private Image _itemIcon;

    private bool _isTaken = false;
    private PeackablItem _item = null;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _itemIcon = GetComponent<Image>();
    }
    
    public void Init(Vector3 position, Vector2 scale)
    {
         _rectTransform = GetComponent<RectTransform>();

        _rectTransform.localPosition = position;
        _rectTransform.sizeDelta = scale;
    }
}
