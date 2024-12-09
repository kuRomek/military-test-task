using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRuntimeMenu : MonoBehaviour
{
    [SerializeField] private Button _backToMainMenuButton;

    private void OnEnable()
    {
        _backToMainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void OnDisable()
    {
        _backToMainMenuButton.onClick.RemoveAllListeners();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
