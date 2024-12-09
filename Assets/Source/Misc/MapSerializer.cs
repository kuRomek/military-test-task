using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class MapSerializer
{
    private const string DateFormat = "yyyy.MM.dd_HH.mm.ss";

    public static void SaveMap(Grid grid)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Maps/" + DateTime.Now.ToString(DateFormat) + ".dat");
        bf.Serialize(file, grid);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public static Grid LoadMap(string mapName)
    {
        if (File.Exists(Application.persistentDataPath + "/Maps/" + mapName + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Maps/" + mapName + ".dat", FileMode.Open);
            file.Position = 0;
            Grid data = (Grid)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game data loaded!");
            return data;
        }
        else
        {
            Debug.LogError("There is no save data!");
            return null;
        }
    }

    public static IEnumerable<MapContext> GetAllSaves()
    {
        string path = $"{Application.persistentDataPath}/Maps/";

        if (Directory.Exists(path) == false)
            yield break;

        foreach (string mapFileName in Directory.GetFiles(path))
        {
            yield return new MapContext(new FileInfo(mapFileName));
        }
    }
}
