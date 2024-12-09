using System;
using UnityEngine;

[Serializable]
public class Grid
{
    private int _worldOffset = -500;
    private int _width;
    private int _height;
    private string[,] _militaryObjects;

    public Grid(Terrain terrain)
    {
        _width = (int)terrain.terrainData.size.x;
        _height = (int)terrain.terrainData.size.z;

        _militaryObjects = new string[_width, _height];

        for (int i = 0; i < _militaryObjects.GetLength(0); i++)
            for (int j = 0; j < _militaryObjects.GetLength(1); j++)
                _militaryObjects[i, j] = null;
    }

    public string[,] MilitaryObjects => _militaryObjects;

    public Vector2Int CalculateGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int((int)worldPosition.x - _worldOffset, (int)worldPosition.z - _worldOffset);
    }

    public Vector3 CalculateWorldPosition(int x, int y)
    {
        return new Vector3(x + _worldOffset, 0f, y + _worldOffset);
    }

    public void Place(MilitaryObject militaryObject)
    {
        Vector2Int gridPosition = CalculateGridPosition(militaryObject.transform.position);

        _militaryObjects[gridPosition.x, gridPosition.y] = militaryObject.gameObject.name.Replace("(Clone)", "");
        militaryObject.PlaceOnGrid();
    }
}
