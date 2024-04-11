using ToDo.Communication.Responses;

namespace ToDo.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    private readonly ToDoDB _db;

    public GetAllTasksUseCase(ToDoDB db)
    {
        _db = db;
    }

    public TaskListResponse Execute()
    {
        var response = new TaskListResponse();

        foreach (var task in _db.Tasks)
        {
            response.Tasks.Add(new TaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = (int) task.Priority,
                Deadline = task.Deadline,
                Status = (int) task.Status,
            });
        }

        return response;
    }
}
