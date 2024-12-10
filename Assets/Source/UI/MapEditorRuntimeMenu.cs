using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapEditorRuntimeMenu : MonoBehaviour
{
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _saveMapButton;
    [SerializeField] private MapNameInputField _mapNameInputField;

    private Grid _grid;

    private void OnEnable()
    {
        _backToMainMenuButton.onClick.AddListener(LoadMainMenu);
        _saveMapButton.onClick.AddListener(_mapNameInputField.Show);
        _mapNameInputField.NameSubmited += OnMapNameSubmited;
    }

    private void OnDisable()
    {
        _backToMainMenuButton.onClick.RemoveAllListeners();
        _saveMapButton.onClick.RemoveAllListeners();
        _mapNameInputField.NameSubmited -= OnMapNameSubmited;
    }

    public void Init(Grid grid)
    {
        _grid = grid;
    }

    private void OnMapNameSubmited(string mapName)
    {
        MapSerializer.SaveMap(_grid, mapName);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
