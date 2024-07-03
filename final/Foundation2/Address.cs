namespace Foundation2;

public class Address
{
    private const string Usa = "USA";
    private const string Us = "US";
    private const string UnitedStates = "UNITEDSTATES";
    private const string UnitedStatesOfAmerica = "UNITEDSTATESOFAMERICA";

    private static readonly HashSet<string> UsaOptions =
    [
        Usa,
        Us,
        UnitedStates, 
        UnitedStatesOfAmerica
    ];

    private readonly string _streetAddress;
    private readonly string _city;
    private readonly string _stateProvince;
    private readonly string _country;

    public Address()
    {
        _streetAddress = string.Empty;
        _city = string.Empty;
        _stateProvince = string.Empty;
        _country = Usa;
    }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress ?? string.Empty;
        _city = city ?? string.Empty;
        _stateProvince = stateProvince ?? string.Empty;
        _country = country ?? Usa;
    }

    public bool IsInUsa()
    {
        return UsaOptions.Contains(_country.Replace(" ", "").ToUpper());
    }

    public override string ToString()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}\n";
    }

    public string GetCountry()
    {
        return _country;
    }
}