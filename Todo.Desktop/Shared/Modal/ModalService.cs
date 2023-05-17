using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Desktop.Shared.Modal;

public class ModalService
{
    private readonly IServiceProvider _provider;
    public ModalService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public TVm Show<TVm>() where TVm: notnull
    {
        var model = _provider.GetRequiredService<TVm>();
        
        ModalView.ShowContent(model);
        
        return model;
    }

    public void Hide()
    {
        ModalView.Hide();
    }
}