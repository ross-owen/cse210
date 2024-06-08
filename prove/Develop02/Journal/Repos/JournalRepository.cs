using System.Text.Json;

namespace Develop02.Journal.Repos;

public class JournalRepository
{
    private readonly DirectoryInfo _repoDir;

    public JournalRepository(DirectoryInfo repoDir)
    {
        if (!repoDir.Exists)
        {
            throw new ArgumentException("Journal directory does not exist");
        }
        _repoDir = repoDir;
    }

    public void Save(Journal journal, string fileName)
    {
        if (journal != null)
        {
            journal.FilePath = new FileInfo(Path.Combine(_repoDir.FullName, fileName)).FullName;
            if (journal.Entries?.Count > 0)
            {
                journal.FirstEntryDate = journal.Entries.Min(je => je.DateRecorded);
                journal.LastEntryDate = journal.Entries.Max(je => je.DateRecorded);
            }

            journal.IsSaved = true;
            var jsonString = JsonSerializer.Serialize(journal);
            File.WriteAllText(journal.FilePath, jsonString);
        }
    }

    public bool Exists(string fileName)
    {
        return new FileInfo(Path.Combine(_repoDir.FullName, fileName)).Exists;
    }

    public Journal Open(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName) && Exists(fileName))
        {
            var filePath = new FileInfo(Path.Combine(_repoDir.FullName, fileName)).FullName;
            var json = File.ReadAllText(filePath);
            var journal = JsonSerializer.Deserialize<Journal>(json);
            journal.FilePath = filePath;
            if (journal.Entries?.Count > 0)
            {
                journal.FirstEntryDate = journal.Entries.Min(je => je.DateRecorded);
                journal.LastEntryDate = journal.Entries.Max(je => je.DateRecorded);
            }

            journal.IsSaved = true;
            return journal;
        }

        return null;
    }
}