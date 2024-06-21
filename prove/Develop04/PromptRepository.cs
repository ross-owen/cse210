using System.Text.Json;

namespace Develop04;

public class PromptRepository
{
    private const string ReflectionPromptFileName = "Prompts/reflection-prompts.json";
    private const string ReflectionsFileName = "Prompts/reflection-questions.json";
    private const string ListingPromptFileName = "Prompts/listing-prompts.json";

    private List<Prompt> _reflectionPrompts;
    private List<Prompt> _reflectionQuestions;
    private List<Prompt> _listingPrompts;

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
        
        var json = File.ReadAllText(ReflectionPromptFileName);
        _reflectionPrompts = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _reflectionPrompts;
    }
    
    public List<Prompt> GetReflectionQuestions()
    {
        if (_reflectionQuestions != null)
        {
            return _reflectionQuestions;
        }
        
        var json = File.ReadAllText(ReflectionsFileName);
        _reflectionQuestions = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _reflectionQuestions;
    }
    
    private List<Prompt> GetListingPrompts()
    {
        if (_listingPrompts != null)
        {
            return _listingPrompts;
        }
        
        var json = File.ReadAllText(ListingPromptFileName);
        _listingPrompts = JsonSerializer.Deserialize<List<Prompt>>(json);

        return _listingPrompts;
    }
}