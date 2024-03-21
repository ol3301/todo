using Microsoft.Extensions.DependencyInjection;
using Todo.Client.Modules.Todo.AddTodo;
using Todo.Client.Modules.Todo.TodoCommandPanel;
using Todo.Client.Modules.Todo.TodoList;

namespace Todo.Client.Modules.Todo;

public static class IServiceCollectionExtensions
{
    public static void AddTodoModule(this IServiceCollection services)
    {
        services.AddTransient<TodoListViewModel>();
        services.AddTransient<TodoCommandPanelViewModel>();
        services.AddTransient<AddTodoViewModel>();
        
        services.AddSingleton<TodoStore>();
    }
}