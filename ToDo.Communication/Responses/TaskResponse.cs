namespace ToDo.Communication.Responses;

public class TaskResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Priority { get; set; }
    public DateTime Deadline { get; set; }
    public int Status { get; set; }
}
