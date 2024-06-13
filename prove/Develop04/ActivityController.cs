using Sandbox.Utils;

namespace Develop04;

public class ActivityController : IController
{
    private readonly PromptRepository _repository;
    
    // I can do this because Guids are considered to be unique, and they certainly are for the ones I've created
    private Dictionary<Guid, PromptType> _usedIds = new();

    public ActivityController(PromptRepository repository)
    {
        _repository = repository;
    }

    public ActivityBase CreateActivity(ActivityType activityType)
    {
        switch (activityType)
        {
            case ActivityType.Breathing:
                return new BreathingActivity();
            case ActivityType.Reflection:
                return new ReflectionActivity(this);
            case ActivityType.Listing:
                return new ListingActivity(this);
            case ActivityType.Pondering:
                return new PonderActivity();
            default:
                throw new ArgumentOutOfRangeException(nameof(activityType), activityType, null);
        }
    }

    public string GetRandomPrompt(PromptType promptType)
    {
        return GetRandomTextFromPrompts(_repository.GetPrompts(promptType), promptType);
    }

    public List<string> GetRandomQuestions(int quantity)
    {
        var questions = new List<string>();
        var allQuestions = _repository.GetReflectionQuestions();
        for (var i = 0; i < quantity; i++)
        {
            questions.Add(GetRandomTextFromPrompts(allQuestions, PromptType.Question));
        }
        return questions;
    }

    // all of this to make a generic method to handle them all - i'm sure i could've done this a better way
    // perhaps actually using generics. However, it is kind of elegant
    // this is probably overkill for this small dataset, but this method will work with large datasets: BOOM!
    private string GetRandomTextFromPrompts(List<Prompt> prompts, PromptType promptType)
    {
        // since the dictionary is keyed by id and value is prompt type, get all the ids for the 
        // given prompt type - these are used - do not use it again, unless they are exhausted
        var usedIds = _usedIds
            .Where(d => d.Value == promptType)
            .Select(d => d.Key)
            .ToHashSet();

        // now get the prompts that aren't used yet so i can pick one
        var unused = prompts.Where(p => !usedIds.Contains(p.Id)).ToList();
        if (unused.Count == 0)
        {
            // since there aren't any unused, let's remove all of them from the used, so we can start over
            // eliminating just the ones of this prompt type
            _usedIds = _usedIds.Where(d => d.Value != promptType).ToDictionary();
            // set the unused to all the prompts that were passed in - all of them that exist
            unused = prompts;
        }

        // randomly select one of the unused prompts (random number is the index in the list) 
        var index = new Random().Next(unused.Count);
        var prompt = unused[index];
        // add the prompt id to the used dictionary
        _usedIds.Add(prompt.Id, promptType);
        
        // return the unused, now used prompt text
        return prompt.Text;
    }
}