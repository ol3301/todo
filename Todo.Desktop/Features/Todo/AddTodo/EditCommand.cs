using Todo.Desktop.Shared;

namespace Todo.Desktop.Features.Todo.AddTodo;

public class EditCommand : CommandBase
{
    private readonly AddTodoViewModel _model;
    private readonly TodoStore _store;
    private readonly ITodoApi _api;

    public EditCommand(AddTodoViewModel model, TodoStore store, ITodoApi api)
    {
        _model = model;
        _store = store;
        _api = api;

        _model.OnProcessingChange += RaiseCanExecuteChanged;
    }

    public override async void Execute(object? parameter)
    {
        _model.Processing = true;
        
        var todo = _store.TodoToModify;

        //var res = await _api.Edit(new TodoItem
        //{
        //    TodoId = todo!.TodoId,
        //    Name = _model.Todo.Name,
        //    Details = _model.Todo.Details,
        //    PlannedOn = _model.Todo.PlannedOn
        //});

        //if (!res.IsSuccessStatusCode)
        //{
        //    return;
        //}

        todo.Name = _model.Todo.Name;
        todo.Details = _model.Todo.Details;
        todo.PlannedOn = _model.Todo.PlannedOn;
        
        _model.Processing = false;
    }

    public override bool CanExecute(object? parameter)
    {
        return !_model.Processing;
    }

}