namespace Foundation3;

public class OutdoorGathering : EventBase
{
    private readonly string _weatherPostalCode;

    public OutdoorGathering(string title, string description, DateTime date, Address address, string weatherPostalCode) : base(title, description, date, address)
    {
        _weatherPostalCode = weatherPostalCode;
    }

    protected override string GetSpecificDetails()
    {
        var numberOfDaysUntil = (GetEventDate() - DateTime.Today).Days;
        return numberOfDaysUntil > 14 
            ? $"Weather: There are {numberOfDaysUntil} days until {GetTitle()}. It is too soon to tell, but we hope it will be fantastic!\n" 
            : $"Weather: Forecast for {_weatherPostalCode} on {GetEventDate():MMMMM d} is Partly Cloudy with highs of 85° F\n";
    }

    protected override string GetEventTypeName()
    {
        return "Outdoor Gathering";
    }
}