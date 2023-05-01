using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace Todo.Desktop.Shared.Navigation;

public class NavigationViewModel : ReactiveObject, IActivatableViewModel
{
    private object _currentViewModel;
    public object CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public NavigationViewModel(NavigationStore store)
    {
        Activator = new ViewModelActivator();
        
        this.WhenActivated(disposables =>
        {
            store.CurrentViewModel
                .Subscribe(model => CurrentViewModel = model)
                .DisposeWith(disposables);
        });
    }

    public ViewModelActivator Activator { get; }
}