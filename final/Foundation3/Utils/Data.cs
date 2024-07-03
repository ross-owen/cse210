using System.Text;

namespace Foundation3.Utils;

public class Data
{
    public static List<string> Apostles =
    [
        "President Russell M. Nelson",
        "President Dallin H. Oaks",
        "President Henry B. Eyring",
        "Elder Jeffrey R. Holland",
        "Elder Henry B. Eyring",
        "Elder Dieter F. Uchtdorf",
        "Elder David A. Bednar",
        "Elder Quentin L. Cook",
        "Elder D. Todd Christofferson",
        "Elder Neil L. Andersen",
        "Elder Ronald A. Rasband",
        "Elder Gary E. Stevenson",
        "Elder Dale G. Renlund",
        "Elder Gerrit W. Gong",
        "Elder Ulisses Soares",
        "Elder Patrick Kearon"
    ];

    public static Dictionary<string, string> Lectures = new()
    {
        {
            "Jesus Christ",
            "Central to the faith of Latter-day Saints is belief in Jesus Christ as the Son of God and Savior of mankind."
        },
        {
            "The Plan of Salvation",
            "Latter-day Saints believe in a premortal existence, our purpose on earth, and the opportunity for eternal life."
        },
        {
            "The Book of Mormon",
            "Another testament of Jesus Christ, the Book of Mormon is seen as sacred scripture alongside the Bible."
        },
        {
            "Joseph Smith",
            "Founder of The Church of Jesus Christ of Latter-day Saints, Joseph Smith is revered as a prophet."
        },
        {
            "The Restoration",
            "The Church teaches that much that was lost from prior Christian traditions has been restored through Joseph Smith."
        },
        {
            "Prophets and Apostles",
            "Latter-day Saints believe in ongoing prophetic revelation through prophets and apostles."
        },
        {
            "Temples",
            "Temples are sacred places for special ordinances, such as baptism for the dead and eternal marriage."
        },
        {
            "Priesthood",
            "The Church practices a priesthood system through which men and young men hold the authority to act in God’s name."
        },
        { "Sacraments", "The sacrament of bread and water represents the body and blood of Christ." },
        { "Ordinances and Covenants", "Sacred ceremonies and promises made with God." },
        { "The Fall of Adam and Eve", "The introduction of sin and mortality into the world." },
        { "The Atonement of Jesus Christ", "Jesus Christ’s sacrifice allows for us to overcome sin and death." },
        { "Faith", "An underlying principle in the Gospel, requiring belief in things unseen." },
        { "Repentance", "The process of changing our hearts and actions to become more like Christ." },
        { "Baptism", "An ordinance of washing away sins and entering into a covenant with God." },
        { "The Holy Ghost", "The third member of the Godhead, a personage of spirit who can guide and comfort us." },
        { "The Second Coming of Christ", "The prophesied return of Jesus Christ to earth." },
        { "Eternal Life", "The potential for us to live forever in God’s presence." },
        { "Families", "Families are central to God’s plan, with the potential to be sealed together eternally." },
        { "Exaltation", "The highest degree of eternal life in God’s presence." }
    };

    public static List<string> Reception =
    [
        "Eleanor Davies & Michael Thompson",
        "Isabella Reyes & William Chen",
        "Sophia Miller & Alexander Garcia",
        "Olivia Jones & David Lee",
        "Charlotte Young & Ethan Kim",
        "Ava Brown & Noah Patel",
        "Mia Hernandez & Benjamin Johnson",
        "Evelyn Wilson & Daniel Walker",
        "Lily Robinson & Matthew Hernandez",
        "Sofia Lopez & Christopher Allen",
        "Chloe Lewis & Andrew Garcia",
        "Grace Moore & Samuel Jackson",
        "Emily Sanchez & Joseph Young",
        "Abigail Clark & Nicholas Miller",
        "Madison Thomas & Ryan Williams",
        "Layla Garcia & Kevin Brown",
        "Scarlett Hernandez & Gabriel Jones",
        "Hannah Walker & David Robinson",
        "Ella Moore & Matthew Lopez",
        "Victoria Allen & Christopher Smith"
    ];

    public static List<string> OutdoorGatherings =
    [
        "Sunsets & S'mores Social",
        "Backyard Bonanza Bash",
        "Moonlight Movie Marathon",
        "Fireflies & Flicks",
        "Games Galore in the Garden",
        "Stargazing Soiree",
        "Wildflower Walk & Picnic",
        "Grill & Chill by the Pool",
        "Under the Oaks Outdoor Uke Jam",
        "Backyard BBQ & Board Games",
        "Artisan Market & Outdoor Movie Night",
        "Community Cornhole Challenge",
        "Fall Festival Fun Fair",
        "Campfire Cocktails & Conversation",
        "Patio Potluck & Ping Pong",
        "Hike & Hangout with Brunch",
        "Bocce Ball Bash & Soda Spritz",
        "Arts & Crafts Under the Canopy",
        "Sunset Yoga & Snacks",
        "Glow-in-the-Dark Games Gathering"
    ];
    
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
    
    public static string Randing(int size)
    {
        var builder = new StringBuilder();
        var wordSeparator = 10;
        for (var i = 0; i < size; i++)
        {
            if (i % wordSeparator == 0)
            {
                builder.Append(' '); // add a random space
                wordSeparator = new Random().Next(5, 11);
            }
            var asciiChar = (int)Math.Floor(new Random().NextSingle() * 25) + 97;
            builder.Append(Convert.ToChar(asciiChar));
        }

        return builder.ToString().Trim();
    }

}