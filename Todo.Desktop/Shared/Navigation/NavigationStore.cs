using System;
using System.Reactive.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Navigation;

public class NavigationStore
{
    private readonly IServiceProvider _serviceProvider;

    public ReplaySubject<object> CurrentViewModel;
    
    public NavigationStore(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = new ReplaySubject<object>(1);
    }

    public void Navigate<TVm>()
    {
        CurrentViewModel.OnNext(_serviceProvider.GetRequiredService<TVm>());
    }
}