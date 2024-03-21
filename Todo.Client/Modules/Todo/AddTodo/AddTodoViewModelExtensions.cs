using System;
using ReactiveUI;
using Todo.Client.Modules.Todo.TodoList;

namespace Todo.Client.Modules.Todo.AddTodo;

public static class AddTodoViewModelExtensions
{
    public static void BindAddCommand(this AddTodoViewModel model, 
        TodoStore todoStore,
        Action onExit)
    {
        model.OnExit = onExit;
        model.BindCancelCommand();
        model.IsAddMode = true;
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            var todo = model.GetTodoItem();
            
            todoStore.Todos.Add(todo);
            model.OnExit();
        }, model.ValidationContext.Valid);
    }
    
    public static void BindEditCommand(this AddTodoViewModel model,
        TodoListViewModel todoListViewModel,
        TodoStore todoStore,
        Action onExit)
    {
        model.OnExit = onExit;
        model.BindCancelCommand();
        model.IsAddMode = false;
        
        var selected = todoListViewModel.SelectedTodo!;
        
        model.Name = selected.Name;
        model.Details = selected.Details;
        model.PlannedOn = selected.PlannedOn;
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            selected.Name = model.Name;
            selected.Details = model.Details;
            selected.PlannedOn = model.PlannedOn;

            model.OnExit();
        }, model.ValidationContext.Valid);

        model.DeleteCommand = ReactiveCommand.Create(() =>
        {
            todoStore.Todos.Remove(selected);
            
            model.OnExit();
        });
    }

    private static void BindCancelCommand(this AddTodoViewModel model)
    {
        model.CancelCommand = ReactiveCommand.Create(model.OnExit);
    }
}