namespace Develop02.Journal.Repos;

public class PromptRepository
{
    private readonly FileInfo _file;
    private readonly List<JournalPrompt> _prompts;

    public PromptRepository(FileInfo file)
    {
        if (!file.Exists)
        {
            throw new ArgumentException($"Invalid filename {file.Name}");
        }

        _file = file;

        _prompts = [];

        using var sr = file.OpenText();
        while (sr.ReadLine() is { } line)
        {
            var promptParts = line.Split("~|~");
            var prompt = new JournalPrompt
            {
                Id = new Guid(promptParts[0]),
                Text = promptParts[1]
            };
            _prompts.Add(prompt);
        }
    }

    public JournalPrompt GetPromptById(Guid id)
    {
        return _prompts.SingleOrDefault(p => p.Id == id);
    }

    public JournalPrompt GetRandomPrompt()
    {
        var index = new Random().NextInt64(_prompts.Count);
        return _prompts[(int)index];
    }

    public JournalPrompt CreatePrompt(string text)
    {
        var prompt = new JournalPrompt
        {
            Id = Guid.NewGuid(),
            Text = text
        };
        _prompts.Add(prompt);

        SaveToFile();
        
        return prompt;
    }

    private void SaveToFile()
    {
        using var outputFile = new StreamWriter(_file.Name);
        foreach (var prompt in _prompts)
        {
            outputFile.WriteLine($"{prompt.Id}~|~{prompt.Text}");
        }
    }
}