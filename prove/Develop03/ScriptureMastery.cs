using System.Text.Json.Serialization;

namespace Develop03;

public class ScriptureMastery
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("verses")]
    public List<ScriptureVerse> Verses { get; set; }

    public static ScriptureMastery Create(string book, int chapter, Dictionary<int, string> verses)
    {
        var verseNumbers = verses.Keys.ToList();
        verseNumbers.Sort();

        return new ScriptureMastery
        {
            Title = CreateTitle(book, chapter, verseNumbers),
            Verses = CreateScriptures(book, chapter, verses, verseNumbers),
        };
    }

    private static string CreateTitle(string book, int chapter, List<int> verses)
    {
        var title = $"{book} {chapter}:";
        
        if (verses.Count == 1)
        {
            title += verses[0];
        }
        else
        {
            title += DeriveTitleFromMultipleVerses(verses);
        }

        return title;
    }

    private static string DeriveTitleFromMultipleVerses(List<int> verses)
    {
        // sort the verses
        verses.Sort();
        // create a list of sets - so that we can group scriptures together
        // and create a title that make sense, eg: Mosiah 3:4-5, 7-9
        // where in the example 4, 5 are a set and 7, 8, 9 are a set
        var sets = new List<string>();

        var currentSet = new List<int>();
        // loop through the verses, creating sets
        foreach (var verse in verses)
        {
            if (currentSet.Count == 0)
            {
                currentSet.Add(verse);
            }
            else
            {
                var lastVerseInSet = currentSet[^1];
                // check for continuous sequence
                if (lastVerseInSet + 1 == verse)
                {
                    currentSet.Add(verse);
                }
                // it's not in sequence, finish set and start a new one
                else
                {
                    sets.Add(CreateScriptureSetName(currentSet));
                    // start a new set with this verse in it
                    currentSet = [];
                    currentSet.Add(verse);
                }
            }
        }
        sets.Add(CreateScriptureSetName(currentSet));

        return string.Join(",", sets);
    }

    private static string CreateScriptureSetName(List<int> currentSet)
    {
        // if there is only one verse, no additional formatting is needed 
        // for the set.

        // more than one, take the first and the last and separate them
        // with a hyphen: example: 4,5,6,7 --> 4-7

        return currentSet.Count == 1
            ? $"{currentSet[0]}"
            : $"{currentSet[0]}-{currentSet[^1]}";
    }

    private static List<ScriptureVerse> CreateScriptures(string book, int chapter, Dictionary<int, string> verses, List<int> verseNumbers)
    {
        return verseNumbers
            .Select(verse => new ScriptureVerse
            {
                Verse = verse,
                Text = verses[verse]
            })
            .ToList();
    }
}