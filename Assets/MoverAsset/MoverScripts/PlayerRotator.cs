using UnityEngine;

public class PlayerRotator : MonoBehaviour
{   
    [SerializeField] private MoverSetting _setting;
    [SerializeField] private Camera _camera;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate(Vector3 rotateDirection)
    {
        yRotation += rotateDirection.x * Time.fixedDeltaTime* _setting.XRotateSpeed;
        xRotation -= rotateDirection.y * Time.fixedDeltaTime*_setting.YRotateSpeed;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        _camera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0,yRotation, 0);    
    }
}
