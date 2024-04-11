using ToDo.Communication.Responses;

namespace ToDo.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    private readonly ToDoDB _db;

    public GetTaskByIdUseCase(ToDoDB db)
    {
        _db = db;
    }

    public TaskResponse? Execute(int taskId)
    {
        var item = _db.Tasks.Find(t => t.Id == taskId);

        if (item is null) return null;

        return new TaskResponse
        {
            Id = item!.Id,
            Name = item.Name,
            Description = item.Description,
            Deadline = item.Deadline,
            Priority = (int) item.Priority,
            Status = (int) item.Status
        };
    }
}
