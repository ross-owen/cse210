using System.Text;
using Foundation2.Utils;

namespace Foundation2;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        var orderCount = new Random().Next(2, 5);
        for (var i = 0; i < orderCount; i++)
        {
            var order = CreateOrder();
            PrintInColor("==================", color: ConsoleColor.Red);
            PrintInColor("Order Number", order.GetOrderNumber());
            PrintInColor("Customer", order.GetCustomerName());
            PrintInColor("Products", order.GetProductCount().ToString());
            PrintInColor("Total", order.GetTotalCost().ToString("C2"));
            Console.WriteLine("------------------");
            PrintInColor("Packing Label", $"{order.GetItemCount().ToString()} items total", ConsoleColor.Green);
            Console.Write(order.GetPackingLabel());
            Console.WriteLine("------------------");
            PrintInColor("Shipping Label", order.GetCountryAndShipping(), ConsoleColor.DarkCyan);
            Console.Write(order.GetShippingLabel());
            PrintInColor("==================", color: ConsoleColor.Red);
            Console.WriteLine();
        }
    }

    private static Order CreateOrder()
    {
        var streetAddress = $"{new Random().Next(1, 9999)} {Pick(Data.Directionals)} {Pick(Data.StreetNames)} {Pick(Data.StreetSuffixes)}";
        var city = Pick(Data.Cities);
        var stateProvince = Pick(Data.StateCountries.Keys.ToList());
        var country = Data.StateCountries[stateProvince];
        var address = new Address(streetAddress, city, stateProvince, country);

        var customerName = $"{Pick(Data.FirstNames)} {Pick(Data.LastNames)}";
        var customer = new Customer(customerName, address);
        
        var order = new Order(customer);

        var productCount = new Random().Next(2, 4);
        var productIds = new HashSet<Guid>();
        for (var i = 0; i < productCount; i++)
        {
            var entity = Data.ProductEntity.Pick();
            while (productIds.Contains(entity.Id))
            {
                entity = Data.ProductEntity.Pick();
            }
            var product = new Product(entity.Id, entity.Name, entity.Price, new Random().Next(1, 4));
            order.AddProduct(product);
            productIds.Add(entity.Id);
        }

        return order;
    }

    private static string Pick(List<string> pickFromThese)
    {
        var index = new Random().Next(pickFromThese.Count);
        return pickFromThese[index];
    }
    
    private static void PrintInColor(string label, string value = null, ConsoleColor color = ConsoleColor.Blue, ConsoleColor? valueColor = null)
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