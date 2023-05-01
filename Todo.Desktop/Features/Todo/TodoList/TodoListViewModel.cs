using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading;
using ReactiveUI;
using Todo.Desktop.Features.Todo.TodoCommandPanel;
using Todo.Desktop.Shared.Modal;
using Todo.Desktop.Shared.Navigation;

namespace Todo.Desktop.Features.Todo.TodoList;

public class TodoListViewModel : ReactiveObject
{
    public ObservableCollection<TodoItem> Todos { get; }

    private TodoItem? _selected;
    public TodoItem? Selected
    {
        get => _selected;
        set => this.RaiseAndSetIfChanged(ref _selected, value);
    }
    
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
    public ReactiveCommand<Unit, Unit> EditCommand { get; set; }
    
    public TodoListViewModel(TodoStore store, ModalStore modalStore)
    {
        Todos = store.Todos;

        this.BindDeleteCommand(store);
        this.BindEditCommand(store, modalStore);
    }
}