using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapEditorRuntimeMenu : MonoBehaviour
{
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _saveMapButton;

    private Grid _grid;

    private void OnEnable()
    {
        _backToMainMenuButton.onClick.AddListener(LoadMainMenu);
        _saveMapButton.onClick.AddListener(() => MapSerializer.SaveMap(_grid));
    }

    private void OnDisable()
    {
        _backToMainMenuButton.onClick.RemoveAllListeners();
        _saveMapButton.onClick.RemoveAllListeners();
    }

    public void Init(Grid grid)
    {
        _grid = grid;
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
