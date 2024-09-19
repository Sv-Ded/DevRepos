using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _yOffset = 1;

    private Vector3 position;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        position = _target.position;
        position.y += _yOffset;
        transform.position = position;
    }
}
