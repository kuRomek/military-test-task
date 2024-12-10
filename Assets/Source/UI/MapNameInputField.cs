using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapNameInputField : UIMenu
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _submitButton;

    public event Action<string> NameSubmited;

    private void OnEnable()
    {
        _submitButton.onClick.AddListener(SubmitName);
    }

    private void OnDisable()
    {
        _submitButton.onClick.RemoveAllListeners();
    }

    public void SubmitName()
    {
        Hide();
        NameSubmited?.Invoke(_inputField.text);
    }
}
