using ReactiveUI;
using Todo.Desktop.Features.Todo.TodoCommandPanel;

namespace Todo.Desktop.Pages.Main;

public class MainWindowViewModel : ReactiveObject
{
    public TodoCommandPanelViewModel TodoCommandPanelViewModel { get; }
    public MainWindowViewModel(TodoCommandPanelViewModel todoCommandPanelViewModel)
    {
        TodoCommandPanelViewModel = todoCommandPanelViewModel;
    }
}