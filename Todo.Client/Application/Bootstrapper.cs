using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Client.Modules.Todo;
using Todo.Client.Modules.Todo.AddTodo;
using Todo.Client.Modules.Todo.TodoCommandPanel;
using Todo.Client.Modules.Todo.TodoList;
using Todo.Client.Pages.Main;
using Todo.Client.Pages.UnhandledException;
using Todo.Client.Shared.Modal;
using Todo.Client.Shared.Navigation;

namespace Todo.Client.Application;

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
                
                services.AddTransient<OneModel>();
                    
                services.AddSingleton<TodoStore>();
                    
                services.AddTransient<NavigationService>();
                services.AddTransient<ModalService>();
            })
            .Build();
    }
}