using System;
using System.Reactive;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Todo.Desktop.Features.Todo.AddTodo;

namespace Todo.Desktop.Shared.Modal;

public class ModalViewModel : ReactiveObject
{
    private readonly ModalStore _store;
    private object _currentViewModel;
    
    public object CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    private bool _isModalVisible;

    public bool IsModalVisible
    {
        get => _isModalVisible;
        set => this.RaiseAndSetIfChanged(ref _isModalVisible, value);
    }
    
    public ModalViewModel(ModalStore store)
    {
        _store = store;
        store.CurrentViewModel.Subscribe(model => CurrentViewModel = model);
        store.IsModalVisible.Subscribe(visible => IsModalVisible = visible);
    }

    public void HideModal()
    {
        _store.Hide();
    }
}