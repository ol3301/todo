using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Navigation;

public class NavigationService
{
    private readonly NavigationStore _navigationStore;
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(NavigationStore navigationStore, IServiceProvider serviceProvider)
    {
        _navigationStore = navigationStore;
        _serviceProvider = serviceProvider;
    }

    public void Navigate<TVm>()
    {
        if(_navigationStore.CurrentViewModel is IDisposable disposable)
            disposable.Dispose();
        
        _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<TVm>();
    }
}