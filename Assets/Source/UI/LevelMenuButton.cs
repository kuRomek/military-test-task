using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuButton : MonoBehaviour
{
    [SerializeField] private Button _loadLevelButton;
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private TextMeshProUGUI _levelCreationDate;

    public void Init(int rowNumber, Map map)
    {
        _number.text = rowNumber.ToString();
        _levelName.text = map.Name;
        _levelCreationDate.text = map.CreationDate.Date.ToString();
    }
}
