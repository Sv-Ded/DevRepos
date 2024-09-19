
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IBaseInventory
{
    public  Cell[] Cells { get; private set; }

    public Inventory(int cellsCount)
    {
        Cells = GetCells(cellsCount);
    }

    public bool Add(PeackablItem item)
    {
        //if (_freeCells > item.ItemInfo.CellsCount && _freeCells > 0)
        //{
        //    _items.Add(item);
        //    _freeCells -= item.ItemInfo.CellsCount;
        //    item.OnPeacked();

        //    return true;
        //}

        //Debug.Log("Недостаточно клеток");
        return false;
    }

    public bool Remove(PeackablItem item)
    {
        //if (_items.Remove(item))
        //{
        //    item.OnDropped();
        //    _freeCells += item.ItemInfo.CellsCount;
        //    return true;
        //}

        Debug.Log("Нет предмета");
        return false;
    }

    #region services

    private Cell[] GetCells(int size)
    {
        Cell[] cells = new Cell[size];

        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = new Cell();
        }

        return cells;
    }

    #endregion
}