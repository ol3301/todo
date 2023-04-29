using System;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public static class Logic
{
    public static void BindAddCommand(this TodoCommandPanelViewModel model, NavigationStore navigationStore,
        TodoStore store)
    {
        model.AddCommand = ReactiveCommand.Create(() =>
        {
            store.Mode = StoreMode.Add;
            navigationStore.Navigate<AddTodoViewModel>();
        });
    }
    
    public static void BindHomeCommand(this TodoCommandPanelViewModel model, NavigationStore navigationStore)
    {
        model.HomeCommand = ReactiveCommand.Create(() =>
        {
            navigationStore.Navigate<TodoListViewModel>();
        });
    }
}