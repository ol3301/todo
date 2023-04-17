using System.Windows.Input;
using Todo.Desktop.Features.Todo.TodoList;
using Todo.Desktop.Shared;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public class TodoCommandPanelViewModel : ViewModelBase
{
    public ICommand AddCommand { get; }
    public ICommand HomeCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand EditCommand { get; }

    public TodoCommandPanelViewModel(NavigationService navigationService,
        TodoStore store,
        ITodoApi api)
    {
        HomeCommand = new CommandBase(() => navigationService.Navigate<TodoListViewModel>());
        AddCommand = new AddCommand(navigationService, store);
        EditCommand = new EditCommand(navigationService, store);
        DeleteCommand = new DeleteCommand(store, api);
    }
}