using System.Text;

namespace Foundation2;

public class Order
{
    private const double UsaShipping = 5.0;
    private const double WorldShipping = 35.0;
    private static int _orderSeed = 4242000; 

    private readonly string _orderNumber;
    private readonly Customer _customer;
    private readonly List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer ?? throw new ArgumentException("customer is required");
        _orderNumber = (_orderSeed + 1).ToString();
        _products = [];

        _orderSeed++;
    }

    private double GetShippingCost()
    {
        return _customer.IsInUsa() ? UsaShipping : WorldShipping;
    }

    public double GetTotalCost()
    {
        var total = _products.Sum(product => product.GetTotal());
        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        var label = new StringBuilder("Order Number: ").Append(_orderNumber).Append('\n');
        foreach (var product in _products)
        {
            label.Append(product.DisplayForPacking()).Append('\n');
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Order Number: {_orderNumber}\n{_customer.GetAddressLabel()}";
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetOrderNumber()
    {
        return _orderNumber;
    }

    public int GetProductCount()
    {
        return _products.Count;
    }

    public int GetItemCount()
    {
        return _products.Sum(p => p.GetQuantity());
    }

    public string GetCustomerName()
    {
        return _customer.GetName();
    }

    public string GetCountryAndShipping()
    {
        return $"{_customer.GetCountry()} | {GetShippingCost():C2}";
    }
}