using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo.Desktop.Pages.UnhandledException;

public partial class UnhandledExceptionWindow : Window
{
    public UnhandledExceptionWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}