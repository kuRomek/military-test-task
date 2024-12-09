using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class MilitaryObject : MonoBehaviour
{
    [SerializeField] private PlaceableIndicator _placeableIndicator;

    private int _widthOnGrid;
    private int _heightOnGrid;
    private bool _availableToPlace = true;
    private Collider _collider;
    private Rigidbody _rigidbody;

    public int WidthOnGrid => _widthOnGrid;
    public int HeightOnGrid => _heightOnGrid;
    public bool AvailableToPlace => _availableToPlace;

    private void Awake()
    {
        _placeableIndicator = GetComponentInChildren<PlaceableIndicator>(true);
        _placeableIndicator.gameObject.SetActive(true);
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        _widthOnGrid = (int)Mathf.Ceil(_collider.bounds.size.x);
        _heightOnGrid = (int)Mathf.Ceil(_collider.bounds.size.z);
        _placeableIndicator.Init(WidthOnGrid, HeightOnGrid);
        _placeableIndicator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MilitaryObject _))
        {
            _availableToPlace = false;
            _placeableIndicator.SetRedColor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out MilitaryObject _))
        {
            _availableToPlace = false;
            _placeableIndicator.SetRedColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MilitaryObject _))
        {
            _availableToPlace = true;
            _placeableIndicator.SetGreenColor();
        }
    }

    public void SetMapEditorMode()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
    }

    public void SetGameRuntimeMode()
    {
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
    }

    public void OnDragging()
    {
        _placeableIndicator.gameObject.SetActive(true);
    }

    public void PlaceOnGrid()
    {
        _placeableIndicator.gameObject.SetActive(false);
    }
}