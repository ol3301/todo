namespace Todo.API.Models;

public class TodoCreateViewModel
{
    public string Name { get; set; }
    
    public string Details { get; set; }
    
    public DateTimeOffset? PlannedOn { get; set; }
}