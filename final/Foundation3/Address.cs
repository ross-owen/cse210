namespace Foundation3;

public class Address
{
    private const string Usa = "USA";

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

    public override string ToString()
    {
        return $"{_streetAddress}, {_city}, {_stateProvince}\n";
    }
}