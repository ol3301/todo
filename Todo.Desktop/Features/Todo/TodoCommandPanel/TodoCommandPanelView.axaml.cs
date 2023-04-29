using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Desktop.Features.Todo.TodoCommandPanel;

public partial class TodoCommandPanelView : ReactiveUserControl<TodoCommandPanelViewModel>
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