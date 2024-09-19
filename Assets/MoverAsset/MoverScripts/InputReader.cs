using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    private readonly string MouseX = "Mouse X";
    private readonly string MouseY = "Mouse Y";
    private readonly KeyCode Jump = KeyCode.Space;
    private readonly KeyCode Run = KeyCode.LeftShift;
    private readonly KeyCode Crouch = KeyCode.LeftControl;
    private readonly KeyCode PeackUpItem = KeyCode.E;

    private Vector3 _moveDirection;
    private Vector3 _mousePosition;

    public event Action<Vector3> MoveButtonIsPressed;
    public event Action<Vector3> MouseMovementHappened;
    public event Action JumpButtonPressed;
    public event Action RunButtonPressed;
    public event Action CrouchButtonPressed;
    public event Action UseDefaultMovement;
    public event Action PeackUpButtonPressed;

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis(Horizontal),0,Input.GetAxis(Vertical));
        MoveButtonIsPressed?.Invoke(_moveDirection);

        _mousePosition = new Vector3(Input.GetAxis(MouseX), Input.GetAxis(MouseY),0);
        MouseMovementHappened?.Invoke(_mousePosition);

        if (Input.GetKey(Jump))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetKey(Crouch))
        {
            CrouchButtonPressed?.Invoke();
        }
        else if  (Input.GetKey(Run)&& Input.GetKey(KeyCode.W))
        {
            RunButtonPressed?.Invoke();
        }
        else
        {
            UseDefaultMovement?.Invoke();
        }

        if (Input.GetKey(PeackUpItem))
        {
            PeackUpButtonPressed?.Invoke();
        }
    }
}
