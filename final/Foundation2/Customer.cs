namespace Foundation2;

public class Customer
{
    private readonly string _name;
    private readonly Address _address;

    public Customer(string name, Address address)
    {
        _name = name ?? string.Empty;
        _address = address ?? new Address();
    }

    public bool IsInUsa()
    {
        return _address.IsInUsa();
    }

    public string GetAddressLabel()
    {
        return $"{_name}\n{_address.ToString()}";
    }

    public string GetName()
    {
        return _name;
    }

    public string GetCountry()
    {
        return _address.GetCountry();
    }
}