using System;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Todo.Client.Shared.Navigation;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;
    
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public NavigationService()
    {
        
    }
    
    public void NavigateTo<TVm>() where TVm: notnull
    {
        //NavigationView.NavigateTo(Locator.Current.GetService<TVm>()!);
        NavigationView.NavigateTo(_serviceProvider.GetRequiredService<TVm>());
    }
}