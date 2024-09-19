using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] CellView _cellPrefab;

    private List<CellView> _cells;
    private Inventory _inventory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        _cells = new List<CellView>();

        for (int i = 0; i < _inventory.Cells.Length; i++)
        {
            CellView cell = Instantiate(_cellPrefab,transform);
            cell.Init(_inventory.Cells[i]);
            _cells.Add(cell);
        }
    }
}
