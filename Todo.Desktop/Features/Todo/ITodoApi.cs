using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Todo.Desktop.Features.Todo;

public interface ITodoApi
{
    [Get("/api/todo")]
    public Task<IApiResponse<IEnumerable<TodoItem>>> GetAll();

    [Post("/api/todo")]
    public Task<IApiResponse> Create(TodoItem todo);

    [Put("/api/todo/")]
    public Task<IApiResponse> Delete(int id);

    [Put("/api/todo/edit")]
    public Task<IApiResponse> Edit(TodoItem todo);
}