using UnityEngine;

[CreateAssetMenu(fileName = "Military Object", menuName = "Scriptable Objects/Military Object", order = 51)]
public class MilitaryObjectContext : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _thumbnail;
    [SerializeField] private MilitaryObject _militaryObject;

    public string Name => _name;
    public Sprite Thumbnail => _thumbnail;
    public MilitaryObject MilitaryObjectPrefab => _militaryObject;
}
