namespace Todo.Desktop.Shared.Navigation;

public class NavigationViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;

    private object _currentViewModel;
    public object CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged();
        }
    }

    public NavigationViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        CurrentViewModel = _navigationStore.CurrentViewModelChanged;
        _navigationStore.CurrentViewModelChanged += newViewModel => CurrentViewModel = newViewModel ;
    }
}