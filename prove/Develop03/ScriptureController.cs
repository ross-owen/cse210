using Sandbox.Utils;

namespace Develop03;

public class ScriptureController : IController
{
    private readonly ScriptureRepository _repository;

    public ScriptureController(ScriptureRepository repository)
    {
        _repository = repository;
    }

    public List<ScriptureMastery> ListSavedScriptures()
    {
        return _repository.List();
    }

    public ScriptureMastery AddScripture(string book, int chapter, Dictionary<int,string> verses)
    {
        var scriptureSet = ScriptureMastery.Create(book, chapter, verses);
        _repository.Add(scriptureSet);
        return scriptureSet;
    }
}