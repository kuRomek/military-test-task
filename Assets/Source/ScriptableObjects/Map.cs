using System;
using UnityEngine;

[CreateAssetMenu(fileName="Map", menuName="Sctiptable Objects/Map", order=51)]
public class Map : ScriptableObject
{
    public string Name { get; private set; }
    public DateTime CreationDate { get; private set; }

    public void Create(string name, DateTime creationDate)
    {
        Name = name;
        CreationDate = creationDate;
    }
}
