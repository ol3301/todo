using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo.Desktop.Features.Todo.TodoList;

public partial class TodoListView : UserControl
{
    public TodoListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}