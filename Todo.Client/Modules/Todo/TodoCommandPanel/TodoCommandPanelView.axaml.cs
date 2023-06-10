using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Client.Modules.Todo.TodoCommandPanel;

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