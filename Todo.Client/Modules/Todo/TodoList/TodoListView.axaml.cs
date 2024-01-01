using System.Collections.Generic;
using System.Linq;
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
        List<TodoItem> selected = new List<TodoItem>();
        foreach (TodoItem todo in dataGrid.SelectedItems)
            selected.Add(todo);
        
        dataGrid.ContextMenu = new ContextMenu();
        
        MenuItem deleteButton = new MenuItem
        {
            Header = selected.Count > 1 ? $"Delete ({selected.Count})" : "Delete",
            Command = ReactiveCommand.Create(() => ViewModel!.DeleteSelected(selected)),
            IsEnabled = selected.Count > 0
        };

        MenuItem editButton = new MenuItem
        {
            Header = "Edit",
            Command = ReactiveCommand.Create(() => ViewModel!.ShowEditModal()),
            IsEnabled = selected.Count > 0
        };
        
        dataGrid.ContextMenu.ItemsSource = selected.Count switch
        {
            > 1 => new List<MenuItem>{deleteButton},
            _ => new List<MenuItem>{editButton, deleteButton}
        };
    }
}