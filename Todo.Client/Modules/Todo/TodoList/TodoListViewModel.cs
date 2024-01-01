using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Todo.Client.Modules.Todo.AddTodo;
using Todo.Client.Shared.Modal;

namespace Todo.Client.Modules.Todo.TodoList;

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

    public void ShowEditModal()
    {
        _modalService.Show<AddTodoViewModel>()
            .Subscribe(vm => vm.BindEditCommand(this, _modalService));
    }
}