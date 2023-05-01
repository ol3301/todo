using System.Reactive;
using ReactiveUI;
using Todo.Desktop.Shared.Modal;

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

    public AddTodoViewModel(TodoStore todoStore, ModalStore modalStore)
    {
        IsAddMode = todoStore.Mode == StoreMode.Add;

        if (IsAddMode)
            this.BindAddCommand(todoStore, modalStore);
        else
            this.BindEditCommand(todoStore, modalStore);
    }
}