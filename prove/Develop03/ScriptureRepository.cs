using System.Text.Json;

namespace Develop03;

public class ScriptureRepository
{
    private const string FileName = "scriptures.json";
    private readonly DirectoryInfo _repoDir;
    private List<ScriptureMastery> _sets;

    public ScriptureRepository(DirectoryInfo repoDir)
    {
        if (!repoDir.Exists)
        {
            throw new ArgumentException("Scripture Repository does not exist. Check your code");
        }
        _repoDir = repoDir;
    }

    public List<ScriptureMastery> List()
    {
        if (_sets == null || _sets.Count == 0)
        {
            var filePath = new FileInfo(Path.Combine(_repoDir.FullName, FileName)).FullName;
            var json = File.ReadAllText(filePath);
            _sets = string.IsNullOrEmpty(json) 
                ? [] 
                : JsonSerializer.Deserialize<List<ScriptureMastery>>(json);
        }

        return _sets;
    }

    public void Add(ScriptureMastery mastery)
    {
        var sets = List();
        sets.Add(mastery);
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, FileName)).FullName;
        var jsonString = JsonSerializer.Serialize(sets);
        File.WriteAllText(filePath, jsonString);
    }
}