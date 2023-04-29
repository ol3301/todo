using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Desktop.Shared.Navigation;

public partial class NavigationView : ReactiveUserControl<NavigationViewModel>
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