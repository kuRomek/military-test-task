using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : IActivatable
{
    private PlayerInputController _playerInputController;
    private Grid _grid;
    private IReadOnlyList<MilitaryObjectUIElement> _militaryObjectUIElements;
    private MilitaryObject _draggingObject = null;

    public ObjectDragger(PlayerInputController playerInputController, Grid grid, IReadOnlyList<MilitaryObjectUIElement> militaryObjectUIElements)
    {
        _playerInputController = playerInputController;
        _grid = grid;
        _militaryObjectUIElements = militaryObjectUIElements;
    }

    public void Enable()
    {
        foreach (MilitaryObjectUIElement militaryUIElement in _militaryObjectUIElements)
            militaryUIElement.ButtonClicked += OnMilitaryObjectSelected;

        _playerInputController.Dragging += OnDragging;
        _playerInputController.DragCanceled += OnButtonClicked;
    }

    public void Disable()
    {
        foreach (MilitaryObjectUIElement militaryUIElement in _militaryObjectUIElements)
            militaryUIElement.ButtonClicked -= OnMilitaryObjectSelected;

        _playerInputController.Dragging -= OnDragging;
        _playerInputController.DragCanceled -= OnButtonClicked;
    }

    public bool DraggingObject => _draggingObject != null;

    private void OnMilitaryObjectSelected(MilitaryObject militaryObject)
    {
        if (_draggingObject == null)
        {
            _draggingObject = militaryObject;
            _draggingObject.OnDragging();
        }
    }

    private void OnDragging(Vector3 point)
    {
        if (_draggingObject != null)
        {
            Vector3 newPosition = new Vector3(Mathf.Round(point.x) + 0.5f * _draggingObject.WidthOnGrid % 2, 0f, Mathf.Round(point.z) + 0.5f * _draggingObject.HeightOnGrid % 2);

            _draggingObject.transform.position = newPosition;
        }
    }

    private void OnButtonClicked()
    {
        if (_draggingObject != null && _draggingObject.AvailableToPlace)
        {
            _grid.Place(_draggingObject);

            _draggingObject = null;
        }
    }
}