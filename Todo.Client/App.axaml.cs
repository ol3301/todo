using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Client.Application;
using Todo.Client.Modules.Todo;
using Todo.Client.Modules.Todo.TodoList;
using Todo.Client.Pages.Main;
using Todo.Client.Shared.Navigation;

namespace Todo.Client;

public class App : Avalonia.Application
{
    private IHost _host;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        _host = new Bootstrapper()
            .Build()
            .WithMockData()
            .WithPage<TodoListViewModel>()
            .WithGlobalExceptionHandler();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
            desktop.MainWindow.DataContext = _host.Services.GetRequiredService<MainWindowViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}