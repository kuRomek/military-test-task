using System.IO;

public class MapContext
{
    private const string DateFormat = "yyyy/MM/dd HH:mm::ss";

    public string Name { get; private set; }
    public string CreationTime { get; private set; }

    public MapContext(FileInfo map)
    {
        CreationTime = map.CreationTimeUtc.ToString(DateFormat);
        Name = Path.GetFileNameWithoutExtension(map.Name);
    }
}
