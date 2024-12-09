using System.IO;
using UnityEngine;

public class MapEditorRoot : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private Terrain _terrain;
    [SerializeField] private MilitaryObjectsUILoader _militaryObjectsUILoader;
    [SerializeField] private MapEditorRuntimeMenu _editorUI;

    private ObjectDragger _objectDragger;

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
                            militaryObject.SetMapEditorMode();
                        }
                    }
                }
            }
        }
        else
        {
            grid = new Grid(_terrain);
        }

        _objectDragger = new ObjectDragger(_inputController, grid, _militaryObjectsUILoader.GiveAllMilitaryUIElements());
        _editorUI.Init(grid);
    }

    private void OnEnable()
    {
        _objectDragger.Enable();
    }

    private void OnDisable()
    {
        _objectDragger.Disable();
    }
}
