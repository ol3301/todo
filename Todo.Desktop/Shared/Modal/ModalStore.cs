using System;
using System.Reactive.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Modal;

public class ModalStore
{
    private readonly IServiceProvider _provider;
    public ReplaySubject<object?> CurrentViewModel { get; }
    public ModalStore(IServiceProvider provider)
    {
        _provider = provider;
        CurrentViewModel = new ReplaySubject<object?>(1);
    }

    public TVm Show<TVm>() where TVm: notnull
    {
        var model = _provider.GetRequiredService<TVm>();
        
        CurrentViewModel.OnNext(model);
        
        return model;
    }

    public void Hide()
    {
        CurrentViewModel.OnNext(default);
    }
}