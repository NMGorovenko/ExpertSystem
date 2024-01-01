using KnowledgeBase;
using WebExpertSystem.UI.Menu;

namespace WebExpertSystem.UI;

public class UserInterface : IContext
{
    private IUiState state;

    public UserInterface()
    {
        this.state = new MainMenuUiState(this, new WebStackKnowledgeBase());
    }

    public void PrintMenu()
    {
        this.state.PrintCurrentMenu();
    }

    public void Start()
    {
        this.PrintMenu();
        state.ProcessUserInput();
    }

    public void ChangeState(IUiState newUiState)
    {
        this.state = newUiState;
        this.Start();
    }
}