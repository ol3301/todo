using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Todo.Desktop.Features.Todo;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Features.Todo.TodoCommandPanel;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Pages.Main;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop;

public class App : Application
{
    private IHost _host;
    
    public override void Initialize()
    {
        //make it with tabs rather than with navigation service
        AvaloniaXamlLoader.Load(this);

        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<TodoListViewModel>();
                services.AddTransient<NavigationViewModel>();
                services.AddTransient<TodoCommandPanelViewModel>();
                services.AddTransient<AddTodoViewModel>();

                services.AddRefitClient<ITodoApi>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5000"));
                services.AddTransient<NavigationService>();
                services.AddTransient<TodoService>();
                
                services.AddSingleton<TodoStore>();
                services.AddSingleton<NavigationStore>();
            })
            .Build();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
            desktop.MainWindow.DataContext = _host.Services.GetRequiredService<MainWindowViewModel>();
            
            var navigationService = _host.Services.GetRequiredService<NavigationService>();
            var todoService = _host.Services.GetRequiredService<TodoService>();
        
            Dispatcher.UIThread.Post(async () => await todoService.Init());
        
            navigationService.Navigate<TodoListViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}