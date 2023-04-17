using System;

namespace Todo.Desktop.Shared.Navigation;

public class NavigationStore
{
    private object _currentViewMode;

    public object CurrentViewModel
    {
        get => _currentViewMode;
        set
        {
            _currentViewMode = value;
            CurrentViewModelChanged?.Invoke(value);
        }
    }

    public Action<object> CurrentViewModelChanged;
}