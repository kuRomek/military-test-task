using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerInput _input;

    public Action<Vector2> CameraMoved;
    public Action<float> CameraRotated;
    public Action<Vector3> Dragging;
    public Action DragCanceled;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();

        _input.Player.Dragging.performed += OnDragging;
        _input.Player.CameraMovement.performed += OnMovingCamera;
        _input.Player.CameraMovement.canceled += OnMovingCamera;
        _input.Player.CameraRotating.performed += OnRotatingCamera;
        _input.Player.CameraRotating.canceled += OnRotatingCamera;
        _input.Player.MouseClick.canceled += OnDragCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();

        _input.Player.Dragging.performed -= OnDragging;
        _input.Player.CameraMovement.performed -= OnMovingCamera;
        _input.Player.CameraMovement.canceled -= OnMovingCamera;
        _input.Player.CameraRotating.performed -= OnRotatingCamera;
        _input.Player.CameraRotating.canceled -= OnRotatingCamera;
        _input.Player.MouseClick.canceled -= OnDragCanceled;
    }

    private void OnMovingCamera(InputAction.CallbackContext context)
    {
        CameraMoved?.Invoke(context.action.ReadValue<Vector2>());
    }

    private void OnRotatingCamera(InputAction.CallbackContext context)
    {
        CameraRotated?.Invoke(context.action.ReadValue<float>());
    }

    private void OnDragging(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(context.action.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, LayerMask.GetMask("Terrain")))
        {
            if (hit.collider.TryGetComponent(out Terrain _))
                Dragging?.Invoke(hit.point);
        }
    }

    private void OnDragCanceled(InputAction.CallbackContext context)
    {
        DragCanceled?.Invoke();
    }
}
