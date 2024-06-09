namespace Learning04;

class Program
{
    static void Main(string[] args)
    {
        var studentName = "Samuel Bennett";
        
        var assignment = new Assignment(studentName, "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        var mathAssignment = new MathAssignment(studentName, "Fractions", "section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        studentName = "Mary Waters";
        var writingAssignment = new WritingAssignment(studentName, "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}