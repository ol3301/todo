using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo.Desktop.Features.Todo.AddTodo;

public partial class AddTodoView : UserControl
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