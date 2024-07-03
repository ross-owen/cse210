using Foundation3.Utils;

namespace Foundation3;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var r = new Random();

        var events = new List<EventBase>
        {
            CreateLecture(),
            CreateReception(),
            CreateGathering()
        };
        
        foreach (var e in events)
        {
            Console.WriteLine("====================================");
            PrintInColor(e.GetType().Name.ToUpper(), e.GetTitle().ToUpper());
            Console.WriteLine("-----------------");
            PrintInColor("Short Description", color: ConsoleColor.Blue);
            Console.WriteLine("-----------------");
            Console.Write(e.GetShortDescription());
            Console.WriteLine("----------------");
            PrintInColor("Standard Details", color: ConsoleColor.Blue);
            Console.WriteLine("----------------");
            Console.Write(e.GetStandardDetails());
            Console.WriteLine("------------");
            PrintInColor("Full Details", color: ConsoleColor.Blue);
            Console.WriteLine("------------");
            Console.Write(e.GetFullDetails());
            Console.WriteLine("====================================");
            Console.WriteLine();
        }
    }

    private static Lecture CreateLecture()
    {
        var title = Pick(Data.Lectures.Keys.ToList());
        var description = Data.Lectures[title];
        var speaker = Pick(Data.Apostles);
        var maxCapacity = CreateMaxCapacity();

        return new Lecture(title, description, PickDate(), CreateAddress(), speaker, maxCapacity);
    }
    
    private static Reception CreateReception()
    {
        var title = Pick(Data.Reception);
        var description = $"Wedding Reception for {title}";
        var rsvpEmail = $"{Data.Randing(15)}@{Data.Randing(6)}.com".Replace(" ", "-");

        return new Reception(title, description, PickDate(), CreateAddress(), rsvpEmail);
    }

    private static OutdoorGathering CreateGathering()
    {
        var title = Pick(Data.OutdoorGatherings);
        var date = PickDate();
        var description = $"Join us for a '{title} outdoor activity' on {date:MMMM d}";
        var postalCode = $"84{new Random().Next(1, 999).ToString().PadLeft(3, '0')}";

        return new OutdoorGathering(title, description, date, CreateAddress(), postalCode);
    }

    private static int CreateMaxCapacity()
    {
        var r = new Random();
        var maxCapacity = r.Next(20, 1000);
        while (maxCapacity % 10 != 0)
        {
            maxCapacity = r.Next(20, 1000);
        }
        return maxCapacity;
    }

    private static string Pick(List<string> pickFromThese)
    {
        var index = new Random().Next(pickFromThese.Count);
        return pickFromThese[index];
    }

    private static DateTime PickDate()
    {
        var r = new Random();
        var eventDate = DateTime.Today.AddDays(r.Next(3, 30));
        var timeSpan = new TimeSpan(0, r.Next(12, 22), 0, 0);
        var eventDateDate = eventDate.Date + timeSpan;
        return eventDateDate;
    }

    private static Address CreateAddress()
    {
        var streetAddress = $"{new Random().Next(1, 9999)} {Pick(Data.Directionals)} {Pick(Data.StreetNames)} {Pick(Data.StreetSuffixes)}";
        var city = Pick(Data.Cities);
        return new Address(streetAddress, city, "Utah", "USA");
    }
    
    private static void PrintInColor(string label, string value = null, ConsoleColor color = ConsoleColor.DarkBlue, ConsoleColor? valueColor = null)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        if (value == null)
        {
            Console.WriteLine($"{label}");
        }
        else
        {
            Console.Write($"{label}: ");
            Console.ForegroundColor = valueColor ?? oldColor;
            Console.WriteLine(value);
        }

        Console.ForegroundColor = oldColor;
    }
}