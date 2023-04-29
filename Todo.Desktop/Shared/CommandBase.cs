using System;
using System.Windows.Input;

namespace Todo.Desktop.Shared;

public class CommandBase : ICommand
{
    private readonly Action? _action;

    public CommandBase(Action? action)
    {
        _action = action;
    }
    public CommandBase()
    {
        
    }
    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    public virtual void Execute(object? parameter)
    {
        _action?.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}