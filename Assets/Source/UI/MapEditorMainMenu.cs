using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapEditorMainMenu : UIMenu
{
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _createNewMapButton;
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
            _mapElements[^1].Init(++i, new MapUIElement.Data(map.Name, map.CreationTime), false);
        }
    }

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OpenStartMenu);
        _createNewMapButton.onClick.AddListener(OpenMapEditor);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveAllListeners();
        _createNewMapButton.onClick.RemoveAllListeners();
    }

    private void OpenStartMenu()
    {
        Hide();
        _startMenu.Show();
    }

    private void OpenMapEditor()
    {
        SceneManager.LoadScene("MapEditor");
    }
}
