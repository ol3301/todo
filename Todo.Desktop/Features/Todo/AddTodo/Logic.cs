using ReactiveUI;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Features.Todo.AddTodo;

public static class Logic
{
    public static void BindAddCommand(this AddTodoViewModel model, TodoStore todoStore,
        ModalStore modalStore)
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
        
            todoStore.Todos.Add(todo);
            
            modalStore.Hide();
        });
    }
    
    public static void BindEditCommand(this AddTodoViewModel model, TodoStore todoStore,
        ModalStore modalStore)
    {
        model.Todo = TodoItemViewModel.FromTodo(todoStore.TodoToModify!);
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            var todo = todoStore.TodoToModify;
        
            todo.Name = model.Todo.Name;
            todo.Details = model.Todo.Details;
            todo.PlannedOn = model.Todo.PlannedOn;
            
            modalStore.Hide();
        });
    }
}