using System.IO;
using UnityEngine;

public class GameRuntimeRoot : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private Terrain _terrain;

    private void Awake()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/Temp/");

        Grid grid;

        if (files.Length > 0)
        {
            grid = MapSerializer.LoadMap(Path.GetFileNameWithoutExtension(files[0]));

            if (grid == null)
            {
                grid = new Grid(_terrain);
            }
            else
            {
                File.Delete(files[0]);

                for (int i = 0; i < grid.MilitaryObjects.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.MilitaryObjects.GetLength(1); j++)
                    {
                        if (grid.MilitaryObjects[i, j] != null)
                        {
                            MilitaryObject militaryObject = Instantiate(Resources.Load<MilitaryObjectContext>(grid.MilitaryObjects[i, j]).MilitaryObjectPrefab, grid.CalculateWorldPosition(i, j), Quaternion.identity);
                            militaryObject.SetGameRuntimeMode();
                        }
                    }
                }
            }
        }
        else
        {
            grid = new Grid(_terrain);
        }
    }
}
