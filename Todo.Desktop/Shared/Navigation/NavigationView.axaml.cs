using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo.Desktop.Shared.Navigation;

public partial class NavigationView : UserControl
{
    public NavigationView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}