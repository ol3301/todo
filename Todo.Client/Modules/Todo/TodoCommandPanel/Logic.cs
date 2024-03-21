using ReactiveUI;
using Todo.Client.Modules.Todo.AddTodo;
using Todo.Client.Modules.Todo.TodoList;
using Todo.Client.Shared.Modal;
using Todo.Client.Shared.Navigation;

namespace Todo.Client.Modules.Todo.TodoCommandPanel;

public static class Logic
{
    public static void BindAddCommand(this TodoCommandPanelViewModel model, ModalService modalService,
        TodoStore todoStore)
    {
        model.AddCommand = ReactiveCommand.Create(() =>
        {
            modalService.Show<AddTodoViewModel>()
                .BindAddCommand(todoStore, () => modalService.Hide());
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