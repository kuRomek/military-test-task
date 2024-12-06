using UnityEngine;
using UnityEngine.UI;

public class StartMenu : UIMenu
{
    [SerializeField] private MapSelectionMenu _mapSelectionMenu;
    [SerializeField] private MapEditorMenu _mapEditorMenu;
    [SerializeField] private Button _mapSelectionButton;
    [SerializeField] private Button _mapEditorButton;

    private void OnEnable()
    {
        _mapSelectionButton.onClick.AddListener(OpenMapSelection);
        _mapEditorButton.onClick.AddListener(OpenMapEditor);
    }

    private void OnDisable()
    {
        _mapSelectionButton.onClick.RemoveAllListeners();
        _mapEditorButton.onClick.RemoveAllListeners();
    }

    private void OpenMapSelection()
    {
        Hide();
        _mapSelectionMenu.Show();
    }

    private void OpenMapEditor()
    {
        Hide();
        _mapEditorMenu.Show();
    }
}
