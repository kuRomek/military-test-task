using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapEditorMenu : UIMenu
{
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _createNewMapButton;

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
