using Sandbox.Utils;

namespace Develop04;

public class ActivityController : IController
{
    private readonly PromptRepository _repository;

    public ActivityController(PromptRepository repository)
    {
        _repository = repository;
    }

}