using System.Collections.Generic;
using UnityEngine;

public class MilitaryObjectsUILoader : MonoBehaviour
{
    [SerializeField] private MilitaryObjectUIElement _militaryObjectUIPrefab;

    private List<MilitaryObjectUIElement> _militaryObjectUIElements = new List<MilitaryObjectUIElement>();

    private void Awake()
    {
        foreach (MilitaryObjectContext militaryObject in Resources.LoadAll<MilitaryObjectContext>(""))
        {
            MilitaryObjectUIElement militaryObjectUI = Instantiate(_militaryObjectUIPrefab, transform);
            militaryObjectUI.Init(militaryObject);

            _militaryObjectUIElements.Add(militaryObjectUI);
        }
    }

    public IReadOnlyList<MilitaryObjectUIElement> GiveAllMilitaryUIElements()
    {
        return _militaryObjectUIElements;
    }
}
