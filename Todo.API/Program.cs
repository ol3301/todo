using System.Text.Json;
using Todo.API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/todo", async () =>
{
    await Task.Delay(3000);
    var list = new List<TodoItem>();

    for (int i = 0; i < 100; ++i)
    {
        list.Add(new() {TodoId = 1, Name = "Learn", Details = "Improve skills", PlannedOn = DateTimeOffset.Now.AddMinutes(15)});
        list.Add(new() {TodoId = 1, Name = "Work", Details = "Learn money", PlannedOn = DateTimeOffset.Now.AddHours(2)});
        list.Add(new() {TodoId = 1, Name = "Relax", Details = "Spend time with friends", PlannedOn = DateTimeOffset.Now.AddHours(4)});
    }

    return list;
});

app.MapPost("/api/todo", async (TodoCreateViewModel model) =>
{
    Console.WriteLine($"create => {JsonSerializer.Serialize(model)}");
    await Task.Delay(1000);
    return Results.Ok();
});

app.MapPut("/api/todo/edit", async (TodoEditViewModel model) =>
{
    Console.WriteLine($"edit => {JsonSerializer.Serialize(model)}");
    await Task.Delay(1000);
    return Results.Ok();
});

app.MapPut(("/api/todo"), async (int id) =>
{
    Console.WriteLine($"delete => {id}");
    await Task.Delay(1000);
    return Results.Ok();
});

app.Run();