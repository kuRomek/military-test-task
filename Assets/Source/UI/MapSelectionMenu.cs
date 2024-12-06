using UnityEngine;
using UnityEngine.UI;

public class MapSelectionMenu : UIMenu
{
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private Button _backButton;
    [SerializeField] private VerticalLayoutGroup _levelButtonsParent;
    [SerializeField] private LevelMenuButton _levelMenuButtonPrefab;

    private Map[] _maps;

    private void Awake()
    {
        Object[] mapObjects = Resources.FindObjectsOfTypeAll(typeof(Map));

        _maps = new Map[mapObjects.Length];

        for (int i = 0; i < mapObjects.Length; i++)
        {
            _maps[i] = (Map)mapObjects[i];

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
