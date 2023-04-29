using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Desktop.Features.Todo.AddTodo;

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