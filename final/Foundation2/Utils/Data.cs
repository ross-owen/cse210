namespace Foundation2.Utils;

public static class Data
{
    public static readonly List<string> Directionals = ["N", "E", "S", "W"];

    public static readonly List<string> StreetSuffixes =
    [
        "Road",
        "Street",
        "Avenue",
        "Boulevard",
        "Way",
        "Lane",
        "Drive",
        "Terrace",
        "Place",
        "Court"
    ];

    public static readonly Dictionary<string, string> StateCountries = new()
    {
        { "UT", "USA" },
        { "NSW", "AU" },
        { "CA", "USA" },
        { "FL", "USA" },
        { "TX", "USA" },
        { "BC", "CA" },
        { "WA", "USA" },
        { "GA", "USA" },
        { "SP", "BR" },
        { "NC", "USA" },
        { "MI", "USA" },
        { "BE", "CN" },
        { "MA", "USA" },
        { "AZ", "USA" },
        { "TN", "USA" },
        { "EN", "GB" },
        { "NY", "USA" },
        { "IL", "USA" },
        { "PA", "USA" },
        { "OH", "USA" },
        { "IDF", "FR" }
    };

    public static readonly List<string> Cities =
    [
        "Evergreen",
        "Fairhaven",
        "Riviera Sands",
        "Willow Creek",
        "Aurora Bay",
        "Emberton",
        "Harbourtown",
        "Vista Verde",
        "Sunset Springs",
        "Port Haven",
        "Whispering Pines",
        "Stonehaven",
        "Riverbend",
        "Castel Fiore",
        "Oceanside",
        "Windward Bay",
        "Havenwood",
        "Emerald Valley",
        "Golden Ridge",
        "Skyline Peak"
    ];

    public static readonly List<string> StreetNames =
    [
        "Maple",
        "Elmwood",
        "Sunview",
        "Parkside",
        "Market",
        "Oakcrest",
        "Riverside",
        "Liberty",
        "Bluebird",
        "Chestnut",
        "Cherry Blossom",
        "Heritage",
        "Whispering Canyon",
        "Jackson",
        "Main",
        "Evergreen",
        "Seaside",
        "Mill",
        "Bridge",
        "Galaxy"
    ];

    public static readonly List<string> FirstNames =
    [
        "Amelia",
        "Noah",
        "Olivia",
        "Liam",
        "Sophia",
        "William",
        "Ava",
        "James",
        "Isabella",
        "Benjamin",
        "Charlotte",
        "Elijah",
        "Mia",
        "Lucas",
        "Evelyn",
        "Mason",
        "Abigail",
        "Logan",
        "Harper",
        "Michael"
    ];

    public static readonly List<string> LastNames =
    [
        "Miller",
        "Brown",
        "Johnson",
        "Jones",
        "Garcia",
        "Wilson",
        "Davis",
        "Hernandez",
        "Rodriguez",
        "Lopez",
        "Walker",
        "Moore",
        "Lee",
        "Allen",
        "King",
        "Wright",
        "Scott",
        "Robinson",
        "Clark",
        "Lewis"
    ];

    public class ProductEntity
    {
        private static readonly List<string> ProductNames =
        [
            "Ever-glow Essentials",
            "Cozy Haven Crafts",
            "TechNest",
            "The Wandering Wardrobe",
            "Blooming Oasis",
            "Brilliant Bits & Bobs",
            "Crafted with Care",
            "Curated Canvas",
            "The Daily Grind",
            "Sound Wave Symphony",
            "Pocket Pathfinder",
            "The Green Thumb Emporium",
            "The Fitness Foundry",
            "Moonlight Makers",
            "Snack Attack Central",
            "Brilliance by Design",
            "The Organized Nest",
            "Whimsical Wonders",
            "The Everyday Edit",
            "Unboxed Potential"
        ];

        private static List<ProductEntity> _products;

        public Guid Id { get; private init; }
        public string Name { get; private init; }
        public double Price { get; private init; }

        public static ProductEntity Pick()
        {
            while (true)
            {
                if (_products != null)
                {
                    return _products[new Random().Next(_products.Count)];
                }

                _products = [];
                lock (_products)
                {
                    foreach (var name in ProductNames)
                    {
                        _products.Add(new ProductEntity
                        {
                            Id = Guid.NewGuid(), Name = name, Price = Math.Round(new Random().NextDouble() * 100, 2)
                        });
                    }
                }
            }
        }
    }
}