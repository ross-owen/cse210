namespace Develop04;

public class PromptRepository
{
    private const string FileName = "prompts.json";
    private readonly DirectoryInfo _repoDir;

    public PromptRepository(DirectoryInfo repoDir)
    {
        if (!repoDir.Exists)
        {
            throw new ArgumentException("Prompt Directory does not exist. Check your code");
        }
        _repoDir = repoDir;
    }
}