using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Todo.Desktop.Shared.Modal;

public partial class ModalView : ReactiveUserControl<ModalViewModel>
{
    public ModalView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnHideHandler(object? sender, PointerPressedEventArgs e)
    {
        ViewModel!.HideModal();
    }
}