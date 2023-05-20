using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using Todo.Desktop.Modules.Todo.AddTodo;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Modules.Todo.TodoCommandPanel;

public class TodoCommandPanelViewModel : ReactiveObject
{
    public ReactiveCommand<Unit, Unit> AddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> HomeCommand { get; set; }
    public TodoCommandPanelViewModel(NavigationService navigationService,
        ModalService modalService,
        TodoStore store)
    {
        this.BindAddCommand(modalService, store);
        this.BindHomeCommand(navigationService);
    }
}