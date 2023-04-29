using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
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

    public NavigationViewModel(NavigationStore navigationStore)
    {
        Activator = new ViewModelActivator();
        
        this.WhenActivated(disposables =>
        {
            navigationStore.CurrentViewModel
                .Subscribe(model => CurrentViewModel = model)
                .DisposeWith(disposables);
        });
    }

    public ViewModelActivator Activator { get; }
}