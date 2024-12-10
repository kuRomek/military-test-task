using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapUIElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rowNumber;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _creationTime;
    [SerializeField] private Button _loadLevelButton;
    [SerializeField] private Button _deleteLevelButton;

    private bool _isForPlaying = false;

    public event Action MapDeleted;

    private void OnEnable()
    {
        _loadLevelButton.onClick.AddListener(LoadLevel);
        _deleteLevelButton.onClick.AddListener(DeleteLevel);
    }

    private void OnDisable()
    {
        _loadLevelButton.onClick.RemoveAllListeners();
        _deleteLevelButton.onClick.RemoveAllListeners();
    }

    public void Init(int rowNumber, Data data, bool isForPlaying)
    {
        _isForPlaying = isForPlaying;
        _rowNumber.text = rowNumber.ToString();
        _name.text = data.Name;
        _creationTime.text = data.CreationTime;
    }

    private void LoadLevel()
    {
        File.Copy(Application.persistentDataPath + "/Maps/" + _name.text + ".dat", 
                  Application.persistentDataPath + "/Temp/" + _name.text + ".dat");

        if (_isForPlaying)
            SceneManager.LoadScene("GameRuntime");
        else
            SceneManager.LoadScene("MapEditor");
    }

    private void DeleteLevel()
    {
        File.Delete(Application.persistentDataPath + "/Maps/" + _name.text + ".dat");
        MapDeleted?.Invoke();
    }

    public class Data
    {
        public string Name { get; private set; }
        public string CreationTime { get; private set; }

        public Data(string name, string creationTime)
        {
            Name = name;
            CreationTime = creationTime;
        }
    }
}
