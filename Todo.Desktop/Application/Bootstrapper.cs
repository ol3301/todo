using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Desktop.Modules.Todo;
using Todo.Desktop.Modules.Todo.AddTodo;
using Todo.Desktop.Modules.Todo.TodoCommandPanel;
using Todo.Desktop.Modules.Todo.TodoList;
using Todo.Desktop.Pages.Main;
using Todo.Desktop.Pages.UnhandledException;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Application;

public static class Bootstrapper
{
    public static IHost Build()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<TodoListViewModel>();
                services.AddTransient<TodoCommandPanelViewModel>();
                services.AddTransient<AddTodoViewModel>();
                services.AddTransient<UnhandledExceptionService>();
                    
                services.AddSingleton<TodoStore>();
                    
                services.AddSingleton<NavigationService>();
                services.AddSingleton<ModalService>();
            })
            .Build();
    }
}