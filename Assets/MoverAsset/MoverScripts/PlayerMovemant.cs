using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerMovemant : MonoBehaviour
{
    [SerializeField] private MoverSetting _setting;

    private Vector3 _moveDirection;
    private float _speed;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private bool _isReadyToJump = true;
    private bool _isCrouch = false;
    private Vector3 _startScale;
    private float _crouchScale;
    private RaycastHit _slopeHit;
    float _angleBetweenPlane;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation =enabled;
    }

    private void Start()
    {
        _speed = _setting.MoveSpeed;
        _startScale = transform.localScale;
        _crouchScale = transform.localScale.y * _setting.CrouchScaleMultiplier;
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y / 2 + _setting.YOffset, _setting.GroundMask);

        if (_isGrounded)
        {
            _rigidbody.drag = _setting.Drag;
        }
        else
        {
            _rigidbody.drag = _setting.DragInAir;
        }

        SpeedControl();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = transform.forward * direction.z + transform.right * direction.x;

        if (OnSlope())
        {
            Vector3 direction2 = GetSlopeDirection(_moveDirection);
            _rigidbody.AddForce(direction2 * _speed, ForceMode.Force);
            Debug.Log(_speed);
        }

        if (_isGrounded)
        {
            _rigidbody.AddForce(_moveDirection.normalized * _speed, ForceMode.Force);
        }
        else
        {
            _rigidbody.AddForce(_moveDirection.normalized * _speed * _setting.AirMultiplier, ForceMode.Force);
        }
    }

    public void Jump()
    {
        if (_isGrounded && _isReadyToJump)
        {

            _isReadyToJump = false;

            _rigidbody.AddForce(transform.up * _setting.JumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), _setting.JumpCooldown);
        }
    }

    public void ChangeSpeedToRun() => _speed = _setting.RunSpeed;

    public void ChangeSpeedToCrouch()
    {
        _speed = _setting.CrouchSpeed;

        if (!_isCrouch)
        {
            transform.localScale = new Vector3(transform.localScale.x, _crouchScale, transform.localScale.z);

            _rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);

            _isCrouch = true;
        }
    }

    public void ReturnSpeedToDefault()
    {
        _speed = _setting.MoveSpeed;

        transform.localScale = _startScale;

        _isCrouch = false;
    }
    private void ResetJump() => _isReadyToJump = true;

    private void SpeedControl()
    {
        Vector3 tempSpeed = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

        if (tempSpeed.sqrMagnitude > _speed * _speed)
        {
            tempSpeed = tempSpeed.normalized * _speed;

            _rigidbody.velocity = new Vector3(tempSpeed.x, _rigidbody.velocity.y, tempSpeed.z);
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, transform.localScale.y / 2 + _setting.YOffset, _setting.GroundMask))
        {
            _angleBetweenPlane = Vector3.Angle(transform.up, _slopeHit.normal);
            return _angleBetweenPlane < _setting.MaxSlopeAngle && _angleBetweenPlane != 0;
        }

        return false;
    }

    private Vector3 GetSlopeDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, _slopeHit.normal);
    }
}