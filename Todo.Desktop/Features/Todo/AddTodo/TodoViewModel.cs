using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Desktop.Features.Todo.AddTodo;

public class TodoItemViewModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Details { get; set; }
    
    public DateTimeOffset? PlannedOn { get; set; }

    public static TodoItemViewModel FromTodo(TodoItem model)
    {
        return new TodoItemViewModel
        {
            Name = model.Name,
            Details = model.Details,
            PlannedOn = model.PlannedOn
        };
    }
}