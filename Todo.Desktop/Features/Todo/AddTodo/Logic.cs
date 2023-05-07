using ReactiveUI;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Features.Todo.AddTodo;

public static class Logic
{
    public static void BindAddCommand(this AddTodoViewModel model, 
        TodoStore todoStore,
        ModalStore modalStore)
    {
        model.IsAddMode = true;
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            var todo = new TodoItem
            {
                Name = model.Name,
                Details = model.Details,
                PlannedOn = model.PlannedOn
            };
        
            todoStore.Todos.Add(todo);
            modalStore.Hide();
        }, model.ValidationContext.Valid);
    }
    
    public static void BindEditCommand(this AddTodoViewModel model,
        TodoListViewModel todoListViewModel,
        ModalStore modalStore)
    {
        model.IsAddMode = false;
        
        var selected = todoListViewModel.Selected!;
        
        model.Name = selected.Name;
        model.Details = selected.Details;
        model.PlannedOn = selected.PlannedOn;
        
        model.SubmitCommand = ReactiveCommand.Create(() =>
        {
            selected.Name = model.Name;
            selected.Details = model.Details;
            selected.PlannedOn = model.PlannedOn;
            
            modalStore.Hide();
        }, model.ValidationContext.Valid);
    }
}