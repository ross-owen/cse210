namespace Learning02;

public class Job
{
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int? _endYear;

    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }
    public Job(string company, string jobTitle, int startYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
    }

    public void Display()
    {
        var fromTo = $"{_startYear}-current";
        if (_endYear.HasValue)
        {
            fromTo = $"{_startYear}-{_endYear}";
        }
        Console.WriteLine($"{_jobTitle} ({_company}) {fromTo}");
    }
}