namespace Foundation3;

public abstract class EventBase
{
    private readonly string _title;
    private readonly string _description;
    private readonly DateTime _date;
    private readonly Address _address;

    protected EventBase(string title, string description, DateTime date, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _address = address;
    }

    protected abstract string GetSpecificDetails();
    protected abstract string GetEventTypeName();

    public string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_date:MMM d, yyyy}\n" +
               $"Time: {_date:h:mm tt}\n" +
               $"Address: {_address}";
    }

    public string GetFullDetails()
    {
        return $"{GetStandardDetails()}" +
               $"Event type: {GetEventTypeName()}\n" +
               GetSpecificDetails();
    }

    public string GetShortDescription()
    {
        return $"Event type: {GetEventTypeName()}\n" +
               $"Title: {_title}\n" +
               $"Date: {_date:MMM d, yyyy}\n";
    }

    public string GetTitle()
    {
        return _title;
    }

    protected DateTime GetEventDate()
    {
        return _date;
    }
}