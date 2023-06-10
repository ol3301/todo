using System;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace Todo.Client.Pages.UnhandledException;

public class UnhandledExceptionService
{
    public void ShowWindow(Exception ex)
    {
        UnhandledExceptionWindow window = new UnhandledExceptionWindow();
        var desktop = (Avalonia.Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!;
        window.FindControl<TextBox>("StackTraceText").Text = ex.ToString();
        window.ShowDialog(desktop.MainWindow);
    }
}