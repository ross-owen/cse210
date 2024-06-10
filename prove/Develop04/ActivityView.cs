using Sandbox.Utils;

namespace Develop04;

public class ActivityView: ViewBase<ActivityController>
{
    private readonly ActivityController _controller;
    
    private const int LoadScripture = 1;
    private const int PickScripture = 2;
    private const int Memorize = 3;
    private const int Exit = 0;
    
    public ActivityView(ActivityController controller)
    {
        _controller = controller;
        var menu = new Dictionary<int, string>
        {
            { LoadScripture, "Add Your Scripture" },
            { PickScripture, "Pick From Existing" },
            { Memorize, "Memorize" },
        };
        Initialize("Scripture Memory", menu, Exit);
    }

    public override void Show()
    {
        int? choice = null;
        while (choice is not Exit)
        {
            choice = ChooseFromMenu();
            switch (choice)
            {
                case LoadScripture:
                    break;
                case PickScripture:
                    break;
                case Memorize:
                    break;
            }
        }
    }
}