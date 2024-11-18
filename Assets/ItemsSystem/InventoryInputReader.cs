using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInputReader : MonoBehaviour
{
    [SerializeField] private ScriptableInventoryView _inventorySetting;
    [SerializeField] private InventoryView _inventory;


    private void Update()
    {
        Debug.Log(_inventory.GetCellPosition(Input.mousePosition));
    }


}
