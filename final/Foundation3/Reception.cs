namespace Foundation3;

public class Reception : EventBase
{
    private readonly string _rsvpEmailAddress;

    public Reception(string title, string description, DateTime date, Address address, string rsvpEmailAddress) : base(title, description, date, address)
    {
        _rsvpEmailAddress = rsvpEmailAddress;
    }

    protected override string GetSpecificDetails()
    {
        return $"RSVP Email: {_rsvpEmailAddress}\n";
    }

    protected override string GetEventTypeName()
    {
        return "Reception";
    }
}