using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Todo.Desktop.Shared.Modal;

namespace Todo.Desktop.Features.Todo.TodoList;

public class TodoListViewModel : ReactiveObject
{
    public ObservableCollection<TodoItem> Todos { get; }

    [Reactive]
    public TodoItem? Selected { get; set; }
    
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
    public ReactiveCommand<Unit, Unit> EditCommand { get; set; }
    
    public TodoListViewModel(TodoStore todoStore, ModalStore modalStore)
    {
        Todos = todoStore.Todos;

        this.BindDeleteCommand(todoStore);
        this.BindEditCommand(modalStore);
    }
}