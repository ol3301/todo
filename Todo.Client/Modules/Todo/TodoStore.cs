using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoBogus;

namespace Todo.Client.Modules.Todo;

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
            //Todos.Add(new TodoItem{Name = "Test", Details = "Test", PlannedOn = DateTimeOffset.Now});
        }
    }
}