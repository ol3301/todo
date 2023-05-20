using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Todo.Desktop.Modules.Todo.AddTodo;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Modules.Todo.TodoList;

public class TodoListViewModel : ReactiveObject
{
    private ModalService _modalService;
    
    public ObservableCollection<TodoItem> Todos { get; }

    [Reactive]
    public TodoItem? SelectedTodo { get; set; }
    
    public TodoListViewModel(TodoStore todoStore, ModalService modalService)
    {
        Todos = todoStore.Todos;
        _modalService = modalService;
    }

    public void DeleteSelected(IEnumerable<TodoItem> todos)
    {
        Todos.RemoveMany(todos);
    }

    public void ShowEditModal(TodoItem todo)
    {
        _modalService.Show<AddTodoViewModel>()
            .BindEditCommand(this, _modalService);
    }
}