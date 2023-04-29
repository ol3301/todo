using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Todo.Desktop.Features.Todo.AddTodo;

public static class Logic
{
    public static void BindAddCommand(this AddTodoViewModel model, TodoStore store)
    {
        model.Todo = new TodoItemViewModel();
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            var todo = new TodoItem
            {
                Name = model.Todo.Name,
                Details = model.Todo.Details,
                PlannedOn = model.Todo.PlannedOn
            };
        
            store.Todos.Add(todo);
        });
    }
    
    public static void BindEditCommand(this AddTodoViewModel model, TodoStore store)
    {
        model.Todo = TodoItemViewModel.FromTodo(store.TodoToModify!);
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            var todo = store.TodoToModify;
        
            todo.Name = model.Todo.Name;
            todo.Details = model.Todo.Details;
            todo.PlannedOn = model.Todo.PlannedOn;
        });
    }
}