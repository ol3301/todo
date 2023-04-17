using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo;

public class EditCommand : CommandBase
{
    private readonly NavigationService _navigationService;
    private readonly TodoStore _store;

    public EditCommand(NavigationService navigationService, TodoStore store)
    {
        _navigationService = navigationService;
        _store = store;
        _store.SelectedChange += _ => RaiseCanExecuteChanged();
    }

    public override void Execute(object? parameter)
    {
        _store.Mode = StoreMode.Edit;
        _store.TodoToModify = _store.Selected;
        _navigationService.Navigate<AddTodoViewModel>();
    }

    public override bool CanExecute(object? parameter)
    {
        return _store.Selected != null;
    }
}