namespace Develop03;

public class ScriptureVerseToMemorize
{
    private readonly int _id;
    private readonly List<Word> _words;
    
    public ScriptureVerseToMemorize(ScriptureVerse verse)
    {
        _id = verse.Verse;
        _words = verse.Text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        var hidden = 0;
        while (visibleWords.Count > 0 && hidden < count)
        {
            HideWord(visibleWords);
            hidden++;
        }
    }

    private void HideWord(List<Word> visibleWords)
    {
        var index = new Random().Next(visibleWords.Count);
        var word = visibleWords[index];
        word.Hide();
        visibleWords.Remove(word);
    }

    public override string ToString()
    {
        return $"{_id}. {string.Join(' ', _words)}";
    }

    public int VisibleCount()
    {
        return _words.Count(w => !w.IsHidden());
    }
}