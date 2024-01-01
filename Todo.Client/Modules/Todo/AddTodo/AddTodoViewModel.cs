using System;
using System.Reactive;
using System.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Extensions;
using ValidationContext = ReactiveUI.Validation.Contexts.ValidationContext;

namespace Todo.Client.Modules.Todo.AddTodo;

public class AddTodoViewModel : ReactiveObject, IValidatableViewModel
{
    public bool IsAddMode { get; set; }
    
    public ReactiveCommand<Unit, Unit> SubmitCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }

    public ValidationContext ValidationContext { get; } = new();

    public AddTodoViewModel()
    {
        this.ValidationRule(x => x.Name, p => !string.IsNullOrEmpty(p), "Error");
        this.ValidationRule(x => x.Details, p => !string.IsNullOrEmpty(p), "Error");
    }

    [Reactive]
    public string Name { get; set; }
    
    [Reactive]
    public string Details { get; set; }
    
    [Reactive]
    public DateTime? PlannedOn { get; set; }
}