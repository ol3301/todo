using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public class TodoCommandPanelViewModel : ReactiveObject
{
    public ReactiveCommand<Unit, Unit> AddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> HomeCommand { get; set; }
    public TodoCommandPanelViewModel(NavigationStore navigationStore,
        TodoStore store)
    {
        this.BindAddCommand(navigationStore, store);
        this.BindHomeCommand(navigationStore);
    }
}