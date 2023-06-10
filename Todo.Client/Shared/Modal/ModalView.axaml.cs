using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace Todo.Client.Shared.Modal;

public partial class ModalView : UserControl
{
    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<ModalView, bool>(nameof(IsOpen));

    public bool IsOpen
    {
        get => GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    public static ModalView Instance { get; private set; }

    public ModalView()
    {
        InitializeComponent();
        Instance = this;
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

   public static void ShowContent(object content) => Dispatcher.UIThread.Post(() =>
   {
       Instance.FindControl<ContentControl>("ContentControl").Content = content;
       Instance.IsOpen = true;
   });

    public static void Hide() => Dispatcher.UIThread.Post(() =>
    {
        Instance.IsOpen = false;
    });

    private void OnHideHandler(object? sender, PointerPressedEventArgs e)
    {
        Hide();
    }
}