using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectionMenu : UIMenu
{
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private Button _backButton;
    [SerializeField] private VerticalLayoutGroup _levelButtonsParent;
    [SerializeField] private MapUIElement _mapUIElementPrefab;

    private List<MapUIElement> _mapElements;

    private void Awake()
    {
        IEnumerable<MapContext> maps = MapSerializer.GetAllSaves();
        _mapElements = new List<MapUIElement>();

        int i = 0;

        foreach (MapContext map in maps)
        {
            _mapElements.Add(Instantiate(_mapUIElementPrefab, _levelButtonsParent.transform));
            _mapElements[^1].Init(++i, new MapUIElement.Data(map.Name, map.CreationTime), true);
        }
    }

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OpenStartMenu);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    private void OpenStartMenu()
    {
        Hide();
        _startMenu.Show();
    }
}
