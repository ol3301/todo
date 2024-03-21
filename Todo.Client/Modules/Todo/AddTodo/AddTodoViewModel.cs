using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Extensions;
using ValidationContext = ReactiveUI.Validation.Contexts.ValidationContext;

namespace Todo.Client.Modules.Todo.AddTodo;

public class AddTodoViewModel : ReactiveObject, IValidatableViewModel
{
    public Action OnExit;
    
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

    public TodoItem GetTodoItem()
    {
        return new TodoItem
        {
            Name = Name,
            Details = Details,
            PlannedOn = PlannedOn
        };
    }

    [Reactive]
    public string Name { get; set; }
    
    [Reactive]
    public string Details { get; set; }
    
    [Reactive]
    public DateTime? PlannedOn { get; set; }
}