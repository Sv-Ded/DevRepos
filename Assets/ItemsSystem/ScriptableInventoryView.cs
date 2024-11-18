using UnityEngine;

[CreateAssetMenu(fileName = " new Inventory", menuName = "new Inventory", order = 53)]
public class ScriptableInventoryView : ScriptableObject
{
    [field: SerializeField] public Vector2 CellSize { get; private set; } = new Vector2(32, 32);
    [field: SerializeField] public int InventoryWight { get; private set; } = 10;
    [field: SerializeField] public int InventoryHight { get; private set; } = 10;
    [field: SerializeField] public float Ofset { get; private set; } = 10;

    public Vector2 GetInventorySize()
    {
        Vector2 size = new Vector2(CellSize.x * InventoryWight+Ofset, InventoryHight*CellSize.y+Ofset );

        return size;
    }
    
}
