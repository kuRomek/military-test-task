using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotatingSpeed;

    private Vector3 _velocity;
    private Vector3 _rotationVelocity;

    private void Update()
    {
        transform.position += (transform.forward * _velocity.y + transform.right * _velocity.x) * Time.deltaTime;
        transform.Rotate(_rotationVelocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        _inputController.CameraMoved += MoveCamera;
        _inputController.CameraRotated += RotateCamera;
    }

    private void OnDisable()
    {
        _inputController.CameraMoved -= MoveCamera;
        _inputController.CameraRotated -= RotateCamera;
    }

    public void MoveCamera(Vector2 offset)
    {
        _velocity = offset * _speed;
    }

    public void RotateCamera(float direction)
    {
        _rotationVelocity = new Vector3(0f, direction * _rotatingSpeed, 0f);
    }
}
