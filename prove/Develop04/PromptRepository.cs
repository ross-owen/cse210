using System.Text.Json;

namespace Develop04;

public class PromptRepository
{
    private const string ReflectionPromptFileName = "reflection-prompts.json";
    private const string ReflectionsFileName = "reflection-questions.json";
    private const string ListingPromptFileName = "listing-prompts.json";

    private readonly DirectoryInfo _repoDir;
    private List<Prompt> _reflectionPrompts = null;
    private List<Prompt> _reflectionQuestions = null;
    private List<Prompt> _listingPrompts = null;

    public PromptRepository(DirectoryInfo repoDir)
    {
        if (!repoDir.Exists)
        {
            throw new ArgumentException("Prompt Directory does not exist. Check your code");
        }
        _repoDir = repoDir;
    }

    public List<Prompt> GetPrompts(PromptType promptType)
    {
        if (promptType == PromptType.ReflectionPrompt)
        {
            return GetReflectionPrompts();
        }

        return GetListingPrompts();
    }
    
    private List<Prompt> GetReflectionPrompts()
    {
        if (_reflectionPrompts != null)
        {
            return _reflectionPrompts;
        }
        
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, ReflectionPromptFileName)).FullName;
        var json = File.ReadAllText(filePath);
        _reflectionPrompts = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _reflectionPrompts;
    }
    
    public List<Prompt> GetReflectionQuestions()
    {
        if (_reflectionQuestions != null)
        {
            return _reflectionQuestions;
        }
        
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, ReflectionsFileName)).FullName;
        var json = File.ReadAllText(filePath);
        _reflectionQuestions = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _reflectionQuestions;
    }
    
    private List<Prompt> GetListingPrompts()
    {
        if (_listingPrompts != null)
        {
            return _listingPrompts;
        }
        
        var filePath = new FileInfo(Path.Combine(_repoDir.FullName, ListingPromptFileName)).FullName;
        var json = File.ReadAllText(filePath);
        _listingPrompts = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _listingPrompts;
    }
}