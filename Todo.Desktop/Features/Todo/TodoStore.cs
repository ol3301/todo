using System.Collections.ObjectModel;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AutoBogus;

namespace Todo.Desktop.Features.Todo;

public class TodoStore
{
    public ObservableCollection<TodoItem> Todos { get; }
    
    public StoreMode Mode { get; set; }
    
    public Subject<TodoItem?> Selected { get; }
    
    public TodoItem? TodoToModify { get; set; }
    public TodoStore()
    {
        Todos = new ObservableCollection<TodoItem>();
        Selected = new Subject<TodoItem?>();
        Mode = StoreMode.Add;
    }

    public async Task Init()
    {
        Todos.Clear();

        await Task.Delay(2000);

        for (int i = 0; i < 10; ++i)
        {
            Todos.Add(AutoFaker.Generate<TodoItem>());
        }
    }
}