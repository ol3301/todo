using ReactiveUI;
using Todo.Client.Modules.Todo.TodoCommandPanel;

namespace Todo.Client.Pages.Main;

public class MainWindowViewModel : ReactiveObject
{
    public TodoCommandPanelViewModel TodoCommandPanelViewModel { get; }
    public MainWindowViewModel(TodoCommandPanelViewModel todoCommandPanelViewModel)
    {
        TodoCommandPanelViewModel = todoCommandPanelViewModel;
    }
}