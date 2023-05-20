using ReactiveUI;
using Todo.Desktop.Modules.Todo.TodoList;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Modules.Todo.AddTodo;

public static class Logic
{
    public static void BindAddCommand(this AddTodoViewModel model, 
        TodoStore todoStore,
        ModalService modalService)
    {
        model.BindCancelCommand(modalService);
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
            modalService.Hide();
        }, model.ValidationContext.Valid);
    }
    
    public static void BindEditCommand(this AddTodoViewModel model,
        TodoListViewModel todoListViewModel,
        ModalService modalService)
    {
        model.BindCancelCommand(modalService);
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
            
            modalService.Hide();
        }, model.ValidationContext.Valid);
    }

    private static void BindCancelCommand(this AddTodoViewModel model, 
        ModalService modalService)
    {
        model.CancelCommand = ReactiveCommand.Create(modalService.Hide);
    }
}