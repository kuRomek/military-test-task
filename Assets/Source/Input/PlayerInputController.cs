using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerInput _input;
    private ObjectDragger _objectDragger;
    private bool _draggingCamera = false;

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

        _input.Player.Dragging.performed += DragObject;
        _input.Player.DragStarted.performed += StartDraggingCamera;
        _input.Player.DragStarted.canceled += StopMovingCamera;
        _input.Player.DragStarted.canceled += StopMovingObject;
        _input.Player.CameraDragging.performed += DragCamera;
        _input.Player.CameraDragging.canceled += RemoveCameraVelocity;
    }

    private void OnDisable()
    {
        _input.Disable();

        _input.Player.Dragging.performed -= DragObject;
        _input.Player.DragStarted.performed -= StartDraggingCamera;
        _input.Player.DragStarted.canceled -= StopMovingCamera;
        _input.Player.DragStarted.canceled -= StopMovingObject;
        _input.Player.CameraDragging.performed -= DragCamera;
        _input.Player.CameraDragging.canceled -= RemoveCameraVelocity;
    }

    public void Init(ObjectDragger objectDragger)
    {
        _objectDragger = objectDragger;
    }

    private void StartDraggingCamera(InputAction.CallbackContext context)
    {
        if ((_objectDragger == null || _objectDragger.DraggingObject == false) && EventSystem.current.IsPointerOverGameObject() == false)
            _draggingCamera = true;
    }

    private void DragObject(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(context.action.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, LayerMask.GetMask("Terrain")))
        {
            if (hit.collider.TryGetComponent(out Terrain _))
                Dragging?.Invoke(hit.point);
        }
    }

    private void DragCamera(InputAction.CallbackContext context)
    {
        if (_draggingCamera)
            CameraMoved?.Invoke(context.action.ReadValue<Vector2>() * -0.3f);
    }

    private void RemoveCameraVelocity(InputAction.CallbackContext context)
    {
        CameraMoved?.Invoke(Vector2.zero);
    }

    private void StopMovingCamera(InputAction.CallbackContext context)
    {
        if (_draggingCamera)
        {
            CameraMoved?.Invoke(Vector2.zero);
            _draggingCamera = false;
        }
    }

    private void StopMovingObject(InputAction.CallbackContext context)
    {
        DragCanceled?.Invoke();
    }
}
