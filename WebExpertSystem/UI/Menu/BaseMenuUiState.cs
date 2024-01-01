using KnowledgeBase;

namespace WebExpertSystem.UI.Menu;

public abstract class BaseMenuUiState : IUiState
{
    protected IContext context { get; }
    protected WebStackKnowledgeBase knowledgeBase;

    protected abstract IReadOnlyDictionary<MenuItem, Action> MenuItems { get; }
    
    protected BaseMenuUiState(IContext context, WebStackKnowledgeBase knowledgeBase)
    {
        this.context = context;
        this.knowledgeBase = knowledgeBase;
    }
    
    public void PrintCurrentMenu()
    {
        var currentIndex = 1;
        foreach (var (menuNumber, menuTitle) in MenuItems)
        {
            Printer.PrintMessage($"{currentIndex}) {menuNumber.Message}");
            currentIndex++;
        }
    }

    public void ProcessUserInput()
    {
        Printer.PrintMessage("Select menu number");
        var menuNumber = InputMachine.GetNumberFromConsole();
        var menuItem = MenuItems.Keys.FirstOrDefault(item => item.Position == menuNumber);

        if (menuItem != null)
        {
            var action = MenuItems[menuItem];
            action.Invoke();
            context.ChangeState(new MainMenuUiState(context, knowledgeBase));
        }
        else
        {
            Printer.PrintMessage("Incorrect menu item");
            ProcessUserInput();
        }
    }
}