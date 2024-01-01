using KnowledgeBase;

namespace WebExpertSystem.UI.Menu;

public class MainMenuUiState : BaseMenuUiState
{
    protected override IReadOnlyDictionary<MenuItem, Action> MenuItems { get; }
    
    public MainMenuUiState(IContext context, WebStackKnowledgeBase knowledgeBase) 
        : base(context, knowledgeBase)
    {
        this.MenuItems = new Dictionary<MenuItem, Action>()
        {
            { new MenuItem(1, "Выбор типа сайта."), () => context.ChangeState(new SiteTypeSelectorUiState(context, knowledgeBase))},
            { new MenuItem(2, "Выход."), () => Environment.Exit(0) }
        };
    }
}