using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoBogus;

namespace Todo.Desktop.Features.Todo;

public class TodoStore
{
    public ObservableCollection<TodoItem> Todos { get; }
    
    public TodoStore()
    {
        Todos = new ObservableCollection<TodoItem>();
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