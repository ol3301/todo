using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Threading;

namespace Todo.Client.Shared.Navigation;

public partial class NavigationView : UserControl
{
    public static NavigationView Instance { get; private set; }

    public NavigationView()
    {
        InitializeComponent();
        Instance = this;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public static void NavigateTo(object content) => Dispatcher.UIThread.Post(() =>
    {
        Instance.FindControl<ContentControl>("ContentControl")!.Content = content;
    });
}