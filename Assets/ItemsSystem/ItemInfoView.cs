using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ItemInfoView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Render(string itemInfo)
    {
        if (itemInfo != "")
        {
            _text.text = itemInfo + " [E]";
        }
        else
        {
            _text.text = itemInfo;
        }
    }
}
