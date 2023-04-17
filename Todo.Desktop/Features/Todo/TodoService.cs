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
        var res = await _api.GetAll();
        if (!res.IsSuccessStatusCode || res.Content == null)
            return;

        foreach (var item in res.Content.ToList())
        {
            _store.Todos.Add(item);
        }
    }
}