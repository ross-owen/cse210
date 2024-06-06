namespace Learning02;

public class Resume
{
    private string _name;
    private List<Job> _jobs;

    public Resume(string name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        if (_jobs == null)
        {
            _jobs = new List<Job>();
        }

        _jobs.Add(job);
    }

    public void DisplayJobHistory()
    {
        if (_jobs == null)
        {
            Console.WriteLine("Resume does not contain any job employment history yet.");
        }

        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}