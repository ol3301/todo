using System;
using System.Reactive.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Modal;

public class ModalStore
{
    private readonly IServiceProvider _provider;
    public ReplaySubject<object> CurrentViewModel { get; }
    
    public Subject<bool> IsModalVisible { get; }

    public ModalStore(IServiceProvider provider)
    {
        _provider = provider;
        CurrentViewModel = new ReplaySubject<object>(1);
        IsModalVisible = new Subject<bool>();
    }

    public void Show<TVm>()
    {
        CurrentViewModel.OnNext(_provider.GetRequiredService<TVm>());
        IsModalVisible.OnNext(true);
    }

    public void Hide()
    {
        IsModalVisible.OnNext(false);
    }
}