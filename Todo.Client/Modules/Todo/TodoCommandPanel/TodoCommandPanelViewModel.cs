using System.Reactive;
using ReactiveUI;
using Todo.Client.Shared.Modal;
using Todo.Client.Shared.Navigation;

namespace Todo.Client.Modules.Todo.TodoCommandPanel;

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