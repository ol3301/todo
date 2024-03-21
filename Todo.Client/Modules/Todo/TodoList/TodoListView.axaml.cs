using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Todo.Client.Modules.Todo.TodoList;

public partial class TodoListView : ReactiveUserControl<TodoListViewModel>
{
    public TodoListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var dataGrid = (DataGrid)sender!;
        dataGrid.ContextMenu = new ContextMenu();
        
        var selected = dataGrid.SelectedItems.Cast<TodoItem>().Select(item => item);

        var buttonEnabled = selected.Any();

        var deleteButton = CreateMenuItemButton(
            selected.Count() > 1 ? $"Delete ({selected.Count()})" : "Delete",
            ReactiveCommand.Create(() => ViewModel!.DeleteSelected(selected)),
            buttonEnabled);

        var editButton = CreateMenuItemButton("Edit",
            ReactiveCommand.Create(() => ViewModel!.ShowEditModal()),
            buttonEnabled);
        
        dataGrid.ContextMenu.ItemsSource = selected.Count() switch
        {
            > 1 => new List<MenuItem>{deleteButton},
            _ => new List<MenuItem>{editButton, deleteButton}
        };
    }

    private MenuItem CreateMenuItemButton(string header, ICommand command, bool enabled) =>
        new()
        {
            Header = header,
            Command = command,
            IsEnabled = enabled
        };
}