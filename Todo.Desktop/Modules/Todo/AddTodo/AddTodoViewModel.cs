using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Extensions;
using ValidationContext = ReactiveUI.Validation.Contexts.ValidationContext;

namespace Todo.Desktop.Modules.Todo.AddTodo;

public class AddTodoViewModel : ReactiveObject, IValidatableViewModel
{
    public bool IsAddMode { get; set; }
    
    public ReactiveCommand<Unit, Unit> SubmitCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }
    
    public ValidationContext ValidationContext { get; } = new();

    public AddTodoViewModel()
    {
        this.ValidationRule(x => x.Name, p => !string.IsNullOrEmpty(p), "Error");
        this.ValidationRule(x => x.Details, p => !string.IsNullOrEmpty(p), "Error");
        throw new Exception("Dummy exception");
    }

    [Reactive]
    public string Name { get; set; }
    
    [Reactive]
    public string Details { get; set; }
    
    [Reactive]
    public DateTimeOffset? PlannedOn { get; set; }
}