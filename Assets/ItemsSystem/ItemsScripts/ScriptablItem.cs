using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = " new Item", menuName = "Item", order = 53)]
public class ScriptablItem : ScriptableObject
{
    [field:SerializeField] public string Name {  get; private set; }
    [field: SerializeField, Range(1, 10)] public int CellsHeight { get; private set; } = 1;
    [field:SerializeField, Range(1,10)] public int CellsWidth { get; private set; } = 1;
    [field:SerializeField] public bool isStacked {  get; private set; }
    [field:SerializeField] public Sprite ItemIcon {  get; private set; }

    public int CellsCount { get {  return CellsHeight*CellsWidth; } }
}
