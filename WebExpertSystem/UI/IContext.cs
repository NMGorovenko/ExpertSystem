using WebExpertSystem.UI.Menu;

namespace WebExpertSystem.UI;

public interface IContext
{
    void ChangeState(IUiState newUiState);
}