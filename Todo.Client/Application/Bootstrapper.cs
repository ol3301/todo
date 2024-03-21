using System;
using System.Reactive;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Todo.Client.Modules.Todo;
using Todo.Client.Pages.Main;
using Todo.Client.Pages.UnhandledException;
using Todo.Client.Shared.Modal;
using Todo.Client.Shared.Navigation;

namespace Todo.Client.Application;

public class Bootstrapper
{
    private IHost _host;
    public Bootstrapper Build()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTodoModule();
                
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<UnhandledExceptionService>();
                
                services.AddTransient<NavigationService>();
                services.AddTransient<ModalService>();
            })
            .Build();

        return this;
    }
    
    public Bootstrapper WithMockData()
    {
        var todoStore = _host.Services.GetRequiredService<TodoStore>();

        Dispatcher.UIThread.Post(async () => await todoStore.GenerateSomeData());

        return this;
    }

    public Bootstrapper WithPage<TViewModel>() where TViewModel : notnull
    {
        var navigationStore = _host.Services.GetRequiredService<NavigationService>();
        
        navigationStore.NavigateTo<TViewModel>();

        return this;
    }

    public IHost WithGlobalExceptionHandler()
    {
        var exceptionService = _host.Services.GetRequiredService<UnhandledExceptionService>();
        
        RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
            ex =>
            {
                exceptionService.ShowWindow(ex);
            });

        return _host;
    }
}