using ToDo.Application.Enums;

namespace ToDo.Application.Entities;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public Priority Priority { get; set; } = Priority.Low;
    public DateTime Deadline { get; set; }
    public Status Status { get; set; } = Status.InProgress;
}
