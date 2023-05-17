using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Navigation;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;
    
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void NavigateTo<TVm>() where TVm: notnull
    {
        NavigationView.NavigateTo(_serviceProvider.GetRequiredService<TVm>());
    }
}