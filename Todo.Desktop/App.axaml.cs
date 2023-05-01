using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Desktop.Features.Todo;
using Todo.Desktop.Features.Todo.AddTodo;
using Todo.Desktop.Features.Todo.TodoCommandPanel;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Pages.Main;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop;

public class App : Application
{
    public override void Initialize()
    {
        //make it with tabs rather than with navigation service
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<TodoListViewModel>();
                    services.AddTransient<NavigationViewModel>();
                    services.AddTransient<TodoCommandPanelViewModel>();
                    services.AddTransient<AddTodoViewModel>();
                    services.AddTransient<ModalViewModel>();
                    
                    services.AddSingleton<TodoStore>();
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<ModalStore>();
                })
                .Build();
            
            desktop.MainWindow = new MainWindow();
            desktop.MainWindow.DataContext = host.Services.GetRequiredService<MainWindowViewModel>();
            
            var navigationStore = host.Services.GetRequiredService<NavigationStore>();
            var todoStore = host.Services.GetRequiredService<TodoStore>();
        
            Dispatcher.UIThread.Post(async () => await todoStore.Init());
        
            navigationStore.Navigate<TodoListViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}