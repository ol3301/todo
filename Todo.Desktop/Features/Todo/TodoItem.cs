using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Todo.Desktop.Features.Todo;

public class TodoItem: ReactiveObject
{
    [Reactive]
    public string Name { get; set; }
    
    [Reactive]
    public string Details { get; set; }
    
    [Reactive]
    public DateTimeOffset? PlannedOn { get; set; }
}