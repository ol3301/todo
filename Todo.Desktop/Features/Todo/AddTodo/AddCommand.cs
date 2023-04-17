using Todo.Desktop.Shared;

namespace Todo.Desktop.Features.Todo.AddTodo;

public class AddCommand : CommandBase
{
    private readonly AddTodoViewModel _model;
    private readonly TodoStore _store;
    private readonly ITodoApi _api;

    public AddCommand(AddTodoViewModel model, TodoStore store, ITodoApi api)
    {
        _model = model;
        _store = store;
        _api = api;

        _model.OnProcessingChange += RaiseCanExecuteChanged;
    }

    public override async void Execute(object? parameter)
    {
        _model.Processing = true;
        
        var todo = new TodoItem
        {
            Name = _model.Todo.Name,
            Details = _model.Todo.Details,
            PlannedOn = _model.Todo.PlannedOn
        };

        //var res = await _api.Create(todo);
        //
        //if (!res.IsSuccessStatusCode)
        //{
        //    return;
        //}
            
        _store.Todos.Add(todo);
        _model.Processing = false;
    }

    public override bool CanExecute(object? parameter)
    {
        return !_model.Processing;
    }
}