using System;
using System.Reactive.Linq;
using System.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Todo.Desktop.Shared.Modal;

public class ModalViewModel : ReactiveObject
{
    private readonly ModalStore _store;

    public ModalViewModel(ModalStore store)
    {
        _store = store;
        store.CurrentViewModel
            .ObserveOn(SynchronizationContext.Current!)
            .Subscribe(model =>
            {
                CurrentViewModel = model;
                IsModalVisible = model != null;
            });
    }

    [Reactive]
    public object? CurrentViewModel { get; set; }
    
    [Reactive]
    public bool IsModalVisible { get; set; }

    public void HideModal()
    {
        _store.Hide();
    }
}