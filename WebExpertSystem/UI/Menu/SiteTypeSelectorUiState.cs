using System.Reflection.Metadata;
using KnowledgeBase;

namespace WebExpertSystem.UI.Menu;

public class SiteTypeSelectorUiState : BaseMenuUiState
{
    protected override IReadOnlyDictionary<MenuItem, Action> MenuItems { get; }
    
    public SiteTypeSelectorUiState(IContext context, WebStackKnowledgeBase knowledgeBase) 
        : base(context, knowledgeBase)
    {
        MenuItems = new Dictionary<MenuItem, Action>()
        {
            { new MenuItem(1, "Сайт-визитка"), () => GetStack(SiteType.Lending) },
            { new MenuItem(2, "Интернет-магазин"), () => GetStack(SiteType.Shop) },
            { new MenuItem(3, "Социальная сеть"), () => GetStack(SiteType.SocialWeb) },
            { new MenuItem(4, "Парсер"), () => GetStack(SiteType.Parser) },
            { new MenuItem(5, "Назад."), () => context.ChangeState(new MainMenuUiState(context, knowledgeBase)) },
            { new MenuItem(6, "Выход."), () => Environment.Exit(0) }
        };
    }

    private void GetStack(SiteType siteType)
    {
        var getDataFromKnoladgeBase = this.knowledgeBase.SelectStack(siteType);
        Printer.PrintMessage($"Предполагаемый стек: {getDataFromKnoladgeBase}");
        
    }
}