using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MilitaryObjectUIElement : MonoBehaviour
{
    [SerializeField] private Image _picture;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Button _button;

    private MilitaryObject _militaryObjectPrefab;

    public Action<MilitaryObject> ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void Init(MilitaryObjectContext militaryObjectContext)
    {
        _militaryObjectPrefab = militaryObjectContext.MilitaryObjectPrefab;
        _picture.sprite = militaryObjectContext.Thumbnail;
        _name.text = militaryObjectContext.Name;
    }

    private void OnButtonClicked()
    {
        MilitaryObject militaryObject = Instantiate(_militaryObjectPrefab);
        militaryObject.SetMapEditorMode();

        ButtonClicked?.Invoke(militaryObject);
    }
}
