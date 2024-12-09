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

    private bool _isForPlaying = false;

    private void OnEnable()
    {
        _loadLevelButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _loadLevelButton.onClick.RemoveAllListeners();
    }

    public void Init(int rowNumber, Data data, bool isForPlaying)
    {
        _isForPlaying = isForPlaying;
        _rowNumber.text = rowNumber.ToString();
        _name.text = data.Name;
        _creationTime.text = data.CreationTime;
    }

    private void OnButtonClicked()
    {
        File.Copy(Application.persistentDataPath + "/Maps/" + _name.text + ".dat", 
                  Application.persistentDataPath + "/Temp/" + _name.text + ".dat");

        if (_isForPlaying)
            SceneManager.LoadScene("GameRuntime");
        else
            SceneManager.LoadScene("MapEditor");
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
