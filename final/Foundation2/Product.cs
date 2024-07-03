namespace Foundation2;

public class Product
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly double _price;
    private readonly int _quantity;

    public Product(Guid id, string name, double price, int quantity)
    {
        _id = id != Guid.Empty ? id : Guid.NewGuid();
        _name = name ?? string.Empty;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotal()
    {
        return Math.Round(_quantity * _price, 2);
    }

    public override string ToString()
    {
        return $"{_id},{_name},{_quantity},{_price}";
    }

    public string DisplayForPacking()
    {
        return $"{_quantity} each | {GetIdFromGuid()} | {_name}";
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    private string GetIdFromGuid()
    {
        var parts = _id.ToString().Split('-');
        return parts[^1];
    }
}