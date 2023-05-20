using ReactiveUI;
using Todo.Desktop.Modules.Todo.AddTodo;
using Todo.Desktop.Modules.Todo.TodoList;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Modules.Todo.TodoCommandPanel;

public static class Logic
{
    public static void BindAddCommand(this TodoCommandPanelViewModel model, ModalService modalService,
        TodoStore todoStore)
    {
        model.AddCommand = ReactiveCommand.Create(() =>
        {
            modalService.Show<AddTodoViewModel>()
                .BindAddCommand(todoStore, modalService);
        });
    }
    
    public static void BindHomeCommand(this TodoCommandPanelViewModel model, NavigationService navigationService)
    {
        model.HomeCommand = ReactiveCommand.Create(() =>
        {
            navigationService.NavigateTo<TodoListViewModel>();
        });
    }
}