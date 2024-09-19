using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraCaster : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField ]private Camera _camera;

    private RaycastHit _raycastHit;
    private float _maxDistance = 10;

    public PeackablItem ItemForward {  get; private set; }

    public event Action<string> ItemInTheMousePoint;

    private void FixedUpdate()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _raycastHit, _maxDistance, mask))
        {
            ItemForward = _raycastHit.collider.gameObject.GetComponent<PeackablItem>();

            ItemInTheMousePoint?.Invoke(ItemForward.ItemInfo.Name);
        }
        else
        {
            ItemForward = null;

            ItemInTheMousePoint?.Invoke("");
        }
    }
}
