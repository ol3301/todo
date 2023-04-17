using Todo.Desktop.Shared;

namespace Todo.Desktop.Features.Todo;

public class DeleteCommand : CommandBase
{
    private readonly TodoStore _store;
    private readonly ITodoApi _api;
    public DeleteCommand(TodoStore store, ITodoApi api)
    {
        _store = store;
        _api = api;
        _store.SelectedChange += _ => RaiseCanExecuteChanged();
    }

    public override async void Execute(object? parameter)
    {
        _store.Todos.Remove(_store.Selected!);
    }

    public override bool CanExecute(object? parameter)
    {
        return _store.Selected != null;
    }
}