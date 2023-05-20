using System;
using System.Reactive;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Todo.Desktop.Pages.UnhandledException;

namespace Todo.Desktop.Application;

public static class GlobalExceptionHandler
{
    public static void Setup(IHost host)
    {
        var exceptionService = host.Services.GetRequiredService<UnhandledExceptionService>();
        
        RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
            ex =>
            {
                exceptionService.ShowWindow(ex);
            });
    }
}