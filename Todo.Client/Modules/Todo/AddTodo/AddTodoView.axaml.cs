using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Client.Modules.Todo.AddTodo;

public partial class AddTodoView : ReactiveUserControl<AddTodoViewModel>
{
    public AddTodoView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}