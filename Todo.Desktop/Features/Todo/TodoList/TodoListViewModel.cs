using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Threading;
using Todo.Desktop.Shared;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoList;

public class TodoListViewModel : ViewModelBase
{
    private readonly TodoStore _store;
    public ObservableCollection<TodoItem> Todos { get; }

    private TodoItem _selected;
    public TodoItem Selected
    {
        get
        {
            _store.SetSelectedTodo(_selected);
            return _selected;
        }
        set
        {
            _selected = value;
            OnPropertyChanged();
            _store.SetSelectedTodo(value);
        }
    }
    
    public ICommand DeleteCommand { get; }
    
    public ICommand EditCommand { get; }

    public TodoListViewModel(TodoStore store,
        NavigationService navigationService,
        ITodoApi api)
    {
        _store = store;
        Todos = store.Todos;
        EditCommand = new EditCommand(navigationService, store);
        DeleteCommand = new DeleteCommand(store, api);
    }
}