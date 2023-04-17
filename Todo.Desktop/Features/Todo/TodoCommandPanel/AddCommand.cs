using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public class AddCommand : CommandBase
{
    private readonly NavigationService _navigationService;
    private readonly TodoStore _store;
    public AddCommand(NavigationService navigationService, TodoStore store)
    {        
        _navigationService = navigationService;
        _store = store;
    }
    public override void Execute(object? parameter)
    {
        _store.Mode = StoreMode.Add;
        _navigationService.Navigate<AddTodoViewModel>();
    }
}