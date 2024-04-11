namespace ToDo.Communication.Requests;

public class CreateTaskRequest
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Priority { get; set; }
    public DateTime Deadline { get; set; }
}
