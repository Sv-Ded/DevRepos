using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool IsTaken { get; private set; }
    public PeackablItem Item { get; private set; }

    public Cell()
    {
        IsTaken = false;
        Item = null;
    }

    public void SetItem(PeackablItem item)=> Item = item;

    public void RemoveItem()=>Item = null;
}
