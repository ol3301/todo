using System;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Client.Shared.Modal;

public class ModalService
{
    private readonly IServiceProvider _provider;
    public ModalService(IServiceProvider provider)
    {
        _provider = provider;
    }
    public IObservable<TVm> Show<TVm>() where TVm: notnull
    {
        var obs = Observable.Start(() => _provider.GetRequiredService<TVm>());
        obs.Subscribe(vm => ModalView.ShowContent(vm));
        return obs;
    }

    public void Hide()
    {
        ModalView.Hide();
    }
}