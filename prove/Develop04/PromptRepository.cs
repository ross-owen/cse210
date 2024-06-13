using System.Text.Json;

namespace Develop04;

public class PromptRepository
{
    private const string PromptFileName = "prompts.json";
    private const string ReflectionsFileName = "reflections.json";

    private readonly DirectoryInfo _repoDir;
    private List<Prompt> _prompts = null;
    private List<Prompt> _questions = null;

    public PromptRepository(DirectoryInfo repoDir)
    {
        if (!repoDir.Exists)
        {
            throw new ArgumentException("Prompt Directory does not exist. Check your code");
        }
        _repoDir = repoDir;
    }

    public List<Prompt> GetPrompts()
    {
        if (_prompts != null)
        {
            return _prompts;
        }
        
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, PromptFileName)).FullName;
        var json = File.ReadAllText(filePath);
        _prompts = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _prompts;
    }
    
    public List<Prompt> GetQuestions()
    {
        if (_questions != null)
        {
            return _questions;
        }
        
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, ReflectionsFileName)).FullName;
        var json = File.ReadAllText(filePath);
        _questions = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _questions;
    }
}