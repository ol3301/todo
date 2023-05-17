using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public class TodoCommandPanelViewModel : ReactiveObject
{
    public ReactiveCommand<Unit, Unit> AddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> HomeCommand { get; set; }
    public TodoCommandPanelViewModel(NavigationService navigationService,
        ModalService modalStore,
        TodoStore store)
    {
        this.BindAddCommand(modalStore, store);
        this.BindHomeCommand(navigationService);
    }
}