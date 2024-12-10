using System.IO;
using UnityEngine;

public class MapEditorRoot : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private Terrain _terrain;
    [SerializeField] private MilitaryObjectsUILoader _militaryObjectsUILoader;
    [SerializeField] private MapEditorRuntimeMenu _editorUI;

    private ObjectDragger _objectDragger;
    private Grid _grid;

    private void Awake()
    {
        InitMap();

        _objectDragger = new ObjectDragger(_inputController, _grid, _militaryObjectsUILoader.GiveAllMilitaryUIElements());
        _editorUI.Init(_grid);
        _inputController.Init(_objectDragger);
    }

    private void OnEnable()
    {
        _objectDragger.Enable();
    }

    private void OnDisable()
    {
        _objectDragger.Disable();
    }

    private void InitMap()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/Temp/");

        if (files.Length > 0)
        {
            _grid = MapSerializer.LoadMap(Path.GetFileNameWithoutExtension(files[0]));

            if (_grid == null)
            {
                _grid = new Grid(_terrain);
            }
            else
            {
                File.Delete(files[0]);

                for (int i = 0; i < _grid.MilitaryObjects.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.MilitaryObjects.GetLength(1); j++)
                    {
                        if (_grid.MilitaryObjects[i, j] != null)
                        {
                            MilitaryObject militaryObject = Instantiate(Resources.Load<MilitaryObjectContext>(_grid.MilitaryObjects[i, j]).MilitaryObjectPrefab, _grid.CalculateWorldPosition(i, j), Quaternion.identity);
                            militaryObject.SetMapEditorMode();
                        }
                    }
                }
            }
        }
        else
        {
            _grid = new Grid(_terrain);
        }
    }
}
