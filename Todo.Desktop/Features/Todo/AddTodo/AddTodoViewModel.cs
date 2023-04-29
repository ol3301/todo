using System.Reactive;
using Avalonia.Controls.Mixins;
using ReactiveUI;

namespace Todo.Desktop.Features.Todo.AddTodo;

public class AddTodoViewModel : ReactiveObject
{
    private TodoItemViewModel _todo;

    public TodoItemViewModel Todo
    {
        get => _todo;
        set => this.RaiseAndSetIfChanged(ref _todo, value);
    }
    
    public bool IsAddMode { get; }

    public ReactiveCommand<Unit, Unit> SubmitCommand { get; set; }

    public AddTodoViewModel(TodoStore store)
    {
        IsAddMode = store.Mode == StoreMode.Add;

        if (IsAddMode)
            this.BindAddCommand(store);
        else
            this.BindEditCommand(store);
    }
}