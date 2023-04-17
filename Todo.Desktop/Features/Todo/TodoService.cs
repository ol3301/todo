using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace Todo.Desktop.Features.Todo;

public class TodoService
{
    private readonly TodoStore _store;
    private readonly ITodoApi _api;

    public TodoService(TodoStore store, ITodoApi api)
    {
        _store = store;
        _api = api;
    }

    public async Task Init()
    {
        _store.Todos.Clear();

        await Task.Delay(3000);
        var list = new List<TodoItem>();

        for (int i = 0; i < 100; ++i)
        {
            list.Add(new() { TodoId = 1, Name = "Learn", Details = "Improve skills", PlannedOn = DateTimeOffset.Now.AddMinutes(15) });
            list.Add(new() { TodoId = 1, Name = "Work", Details = "Learn money", PlannedOn = DateTimeOffset.Now.AddHours(2) });
            list.Add(new() { TodoId = 1, Name = "Relax", Details = "Spend time with friends", PlannedOn = DateTimeOffset.Now.AddHours(4)});
        }

        foreach (var item in list)
        {
            _store.Todos.Add(item);
        }
    }
}