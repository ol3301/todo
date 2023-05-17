using System.Reactive.Linq;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Features.Todo.TodoList;

public static class Logic
{
    public static void BindDeleteCommand(this TodoListViewModel model, TodoStore todoStore)
    {
        var canExecute = model.WhenAnyValue(x => x.Selected)
            .Select(x => x != null);
        
        model.DeleteCommand = ReactiveCommand.Create(() =>
        {
            todoStore.Todos.Remove(model.Selected);
        }, canExecute);
    }
    
    public static void BindEditCommand(this TodoListViewModel model,
        ModalService modalStore)
    {
        var canExecute = model.WhenAnyValue(x => x.Selected)
            .Select(x => x != null);
        
        model.EditCommand = ReactiveCommand.Create(() =>
        {
            modalStore.Show<AddTodoViewModel>()
                .BindEditCommand(model, modalStore);
        }, canExecute);
    }
}