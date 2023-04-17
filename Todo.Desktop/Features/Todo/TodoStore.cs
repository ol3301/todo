using System;
using System.Collections.ObjectModel;

namespace Todo.Desktop.Features.Todo;

public class TodoStore
{
    public ObservableCollection<TodoItem> Todos { get; set; }
    
    public StoreMode Mode { get; set; }
    
    public TodoItem? Selected { get; private set; }
    
    public TodoItem? TodoToModify { get; set; }
    
    public Action<TodoItem>? SelectedChange { get; set; }

    public TodoStore()
    {
        Todos = new ObservableCollection<TodoItem>();
    }

    public void SetSelectedTodo(TodoItem model)
    {
        Selected = model;
        SelectedChange?.Invoke(model);
    }
}