using System;
using System.Windows.Input;
using Todo.Desktop.Shared;

namespace Todo.Desktop.Features.Todo.AddTodo;

public class AddTodoViewModel : ViewModelBase
{
    private readonly TodoStore _store;

    public TodoItemViewModel Todo { get; }
    
    public bool IsAddMode => _store.Mode == StoreMode.Add;
    
    public ICommand SubmitCommand { get; }

    private bool _processing;

    public bool Processing
    {
        get => _processing;
        set
        {
            _processing = value;
            OnPropertyChanged();
            OnProcessingChange?.Invoke();
        }
    }

    public Action? OnProcessingChange { get; set; }

    public AddTodoViewModel(TodoStore store, ITodoApi api)
    {
        _store = store;
        if (IsAddMode)
        {
            Todo = new TodoItemViewModel();
            SubmitCommand = new AddCommand(this, _store, api);
        }
        else
        {
            Todo = TodoItemViewModel.FromTodo(store.TodoToModify!);
            SubmitCommand = new EditCommand(this, _store, api);
        }
    }
}