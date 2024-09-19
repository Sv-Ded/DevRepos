using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] public ScriptablItem ItemInfo { get; private set; }
}
