using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class InventoryView : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private ScriptableInventoryView _inventorySetting;
    [SerializeField] private RectTransform _cellSpawnPosition;
    
    private List<Cell> _cells;
    private Inventory _inventory;
    private RectTransform _viewRectTransform;

    private Vector2 _positionInInventory;
    private Vector2Int _cellPosition;

    private void Awake()
    {
        _viewRectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        //_inventory.ItemAdded +=
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        _cells = new List<Cell>();
        _viewRectTransform.sizeDelta = _inventorySetting.GetInventorySize();
        Vector3 tempPosition = _cellSpawnPosition.localPosition;

        float cellInLineCount = 0;

        for (int i = 0; i <= _inventory.Items.Length; i++)
        {
            Cell cell = Instantiate(_cellPrefab, transform);
            cell.Init(tempPosition, _inventorySetting.CellSize);
            _cells.Add(cell);

            tempPosition.x += _inventorySetting.CellSize.x+1;
            cellInLineCount++;

            if (cellInLineCount >= _inventorySetting.InventoryWight)
            {
                tempPosition.x = _cellSpawnPosition.localPosition.x;
                tempPosition.y -= _inventorySetting.CellSize.y+1;

                cellInLineCount = 0;
            }
        }
    }

    public Vector2Int GetCellPosition(Vector2 mousePosition)
    {
        _positionInInventory.x = mousePosition.x - _viewRectTransform.anchoredPosition.x;
        _positionInInventory.y = _viewRectTransform.anchoredPosition.y- mousePosition.y;

        _cellPosition.x = (int)(_positionInInventory.x / _inventorySetting.CellSize.x);
        _cellPosition.y = (int)(_positionInInventory.y / _inventorySetting.CellSize.y);

        return _cellPosition;
    }
}
