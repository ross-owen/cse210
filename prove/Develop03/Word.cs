using System.Text.RegularExpressions;

namespace Develop03;

public partial class Word
{
    private readonly string _word;
    private readonly string _hiddenValue;
    private bool _isHidden = false;

    public Word(string word)
    {
        _word = word;
        _hiddenValue = LettersRegex().Replace(word, "_");
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public override string ToString()
    {
        return _isHidden
            ? _hiddenValue
            : _word;
    }

    [GeneratedRegex(@"[a-zA-Z]")]
    private static partial Regex LettersRegex();
}