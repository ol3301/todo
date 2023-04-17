using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public partial class TodoCommandPanelView : UserControl
{
    public TodoCommandPanelView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}