using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Subjects;
using System.Threading.Tasks;

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
    }

    public async Task Init()
    {
        Todos.Clear();

        await Task.Delay(2000);
        var list = new List<TodoItem>();

        for (int i = 0; i < 100; ++i)
        {
            list.Add(new() { TodoId = 1, Name = "Learn", Details = "Improve skills", PlannedOn = DateTimeOffset.Now.AddMinutes(15) });
            list.Add(new() { TodoId = 1, Name = "Work", Details = "Learn money", PlannedOn = DateTimeOffset.Now.AddHours(2) });
            list.Add(new() { TodoId = 1, Name = "Relax", Details = "Spend time with friends", PlannedOn = DateTimeOffset.Now.AddHours(4)});
        }

        foreach (var item in list)
        {
            Todos.Add(item);
        }
    }
}