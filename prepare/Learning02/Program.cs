namespace Learning02;

class Program
{
    static void Main(string[] args)
    {
        var resume = new Resume("Ross L. Owen");
        resume.AddJob(new Job("Filevine", "Software Development Manager", 2023));
        resume.AddJob(new Job("Alianza", "Software Development Team Lead", 2014, 2023));
        resume.DisplayJobHistory();
    }
}