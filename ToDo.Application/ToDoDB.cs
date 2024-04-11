using Entity = ToDo.Application.Entities;

namespace ToDo.Application;

public class ToDoDB
{
    public List<Entity.Task> Tasks { get; set; } = [];
}
