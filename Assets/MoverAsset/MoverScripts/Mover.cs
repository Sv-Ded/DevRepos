using UnityEngine;

[RequireComponent (typeof(InputReader),typeof(PlayerMovemant),typeof(PlayerRotator))]
public class Mover : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMovemant _movement;
    private PlayerRotator _rotator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _movement = GetComponent<PlayerMovemant>();
        _rotator = GetComponent<PlayerRotator>();
    }

    private void OnEnable()
    {
        _inputReader.MoveButtonIsPressed += _movement.Move;
        _inputReader.JumpButtonPressed += _movement.Jump;
        _inputReader.MouseMovementHappened += _rotator.Rotate;
        _inputReader.CrouchButtonPressed += _movement.ChangeSpeedToCrouch;
        _inputReader.RunButtonPressed += _movement.ChangeSpeedToRun;
        _inputReader.UseDefaultMovement += _movement.ReturnSpeedToDefault;
    }

    private void OnDisable()
    {
        _inputReader.MoveButtonIsPressed -= _movement.Move;
        _inputReader.JumpButtonPressed -= _movement.Jump;
        _inputReader.MouseMovementHappened -= _rotator.Rotate;
        _inputReader.CrouchButtonPressed -= _movement.ChangeSpeedToCrouch;
        _inputReader.RunButtonPressed -= _movement.ChangeSpeedToRun;
        _inputReader.UseDefaultMovement -= _movement.ReturnSpeedToDefault;
    }
}
