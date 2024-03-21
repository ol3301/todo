using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Client.Shared.Modal;

public class ModalService
{
    private readonly IServiceProvider _provider;
    public ModalService(IServiceProvider provider)
    {
        _provider = provider;
    }
    public TViewModel Show<TViewModel>() where TViewModel: notnull
    {
        var viewModel = _provider.GetRequiredService<TViewModel>();
        ModalView.ShowContent(viewModel);
        return viewModel;
    }

    public void Hide()
    {
        ModalView.Hide();
    }
}