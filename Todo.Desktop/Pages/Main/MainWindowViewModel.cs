using System.Reactive.Disposables;
using ReactiveUI;
using Todo.Desktop.Features.Todo.TodoCommandPanel;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Pages.Main;

public class MainWindowViewModel : ReactiveObject
{
    public NavigationViewModel NavigationViewModel { get; }
    public TodoCommandPanelViewModel TodoCommandPanelViewModel { get; }
    public ModalViewModel ModalViewModel { get; }

    public MainWindowViewModel( NavigationViewModel navigationViewModel, 
        TodoCommandPanelViewModel todoCommandPanelViewModel,
        ModalViewModel modalViewModel)
    {
        NavigationViewModel = navigationViewModel;
        TodoCommandPanelViewModel = todoCommandPanelViewModel;
        ModalViewModel = modalViewModel;
    }
}