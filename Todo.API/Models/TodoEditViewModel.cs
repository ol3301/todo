namespace Todo.API.Models;

public class TodoEditViewModel
{
    public int TodoId { get; set; }
    
    public string Name { get; set; }
    
    public string Details { get; set; }
    
    public DateTimeOffset? PlannedOn { get; set; }
}