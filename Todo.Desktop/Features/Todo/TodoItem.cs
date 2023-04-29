using System;

namespace Todo.Desktop.Features.Todo;

public class TodoItem
{
    public int TodoId { get; set; }
    
    public string Name { get; set; }
    
    public string Details { get; set; }
    
    public DateTimeOffset? PlannedOn { get; set; }
}