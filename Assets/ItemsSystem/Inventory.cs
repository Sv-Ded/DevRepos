
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IBaseInventory
{
    private int _freeCellsCount;

    public PeackablItem[] Items { get; private set; }

    public event Action<PeackablItem> ItemAdded;

    public Inventory(int cellsCount)
    {
        Items = new PeackablItem[cellsCount];
        _freeCellsCount = cellsCount;
    }

    public bool Add(PeackablItem item)
    {
        if (_freeCellsCount >= item.ItemInfo.CellsCount)
        {
            TakePlace(item);

            _freeCellsCount -= item.ItemInfo.CellsCount;

            ItemAdded?.Invoke(item);

            return true;
        }
        else
        {
            Debug.Log("Недостаточно клеток");
            return false;
        }
    }

    public bool Remove(PeackablItem peackedItem)
    {
        try
        {
            foreach (var cell in Items)
            {
                if (cell == peackedItem)
                {
                    ClearCell(cell);
                }
            }

            _freeCellsCount += peackedItem.ItemInfo.CellsCount;
        }
        catch
        {
            return false;
        }

        return true;
    }

    #region services

    private void TakePlace(PeackablItem item)
    {
        for (int i = 0, j = 0; i < item.ItemInfo.CellsCount; j++)
        {
            if (Items[j] == null)
            {
                i++;

                Items[j] = item;
            }
        }
    }

    private void ClearCell(PeackablItem item) => item = null;

    #endregion
}