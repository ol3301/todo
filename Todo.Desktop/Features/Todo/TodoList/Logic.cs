using System;
using System.Reactive.Linq;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoList;

public static class Logic
{
    public static void BindDeleteCommand(this TodoListViewModel model, TodoStore store)
    {
        var canExecute = model.WhenAnyValue(x => x.Selected)
            .Select(x => x != null);
        
        model.DeleteCommand = ReactiveCommand.Create(() =>
        {
            store.Todos.Remove(model.Selected);
        }, canExecute);
    }
    
    public static void BindEditCommand(this TodoListViewModel model, 
        TodoStore store,
        ModalStore modalStore)
    {
        var canExecute = model.WhenAnyValue(x => x.Selected)
            .Select(x => x != null);
        
        model.EditCommand = ReactiveCommand.Create(() =>
        {
            store.Mode = StoreMode.Edit;
            store.TodoToModify = model.Selected;
            modalStore.Show<AddTodoViewModel>();
        }, canExecute);
    }
}