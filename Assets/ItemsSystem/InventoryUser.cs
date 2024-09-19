using UnityEngine;
using UnityEngine.UI;

public class InventoryUser : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private CameraCaster _camera;
    [SerializeField] private ItemInfoView _infoView;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private InventoryView _inventoryView;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory(_size);
        _inventoryView.Init(_inventory);
    }

    private void OnEnable()
    {
        _camera.ItemInTheMousePoint += _infoView.Render;

        _inputReader.PeackUpButtonPressed += PeackUpItem;
    }

    private void OnDisable()
    {
        _camera.ItemInTheMousePoint -= _infoView.Render;

        _inputReader.PeackUpButtonPressed -= PeackUpItem;
    }

    private void PeackUpItem()
    {
        if (_camera.ItemForward != null)
        {
            _inventory.Add(_camera.ItemForward);
        }
    } 
}