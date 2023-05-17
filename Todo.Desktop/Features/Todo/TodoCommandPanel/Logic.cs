using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public static class Logic
{
    public static void BindAddCommand(this TodoCommandPanelViewModel model, ModalService modalStore,
        TodoStore todoStore)
    {
        model.AddCommand = ReactiveCommand.Create(() =>
        {
            modalStore.Show<AddTodoViewModel>()
                .BindAddCommand(todoStore, modalStore);
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