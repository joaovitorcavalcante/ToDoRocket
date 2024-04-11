using ToDo.Application.Enums;
using ToDo.Communication.Requests;

namespace ToDo.Application.UseCases.Tasks.Create;

public class CreateTaskUseCase
{
    private readonly ToDoDB _db;

    public CreateTaskUseCase(ToDoDB db)
    {
        _db = db;
    }

    public void Execute(CreateTaskRequest input)
    {
        _db.Tasks.Add(new Entities.Task
        {
            Id = new Random().Next(1, (100 * 100)),
            Name = input.Name,
            Description = input.Description,
            Priority = (Priority)input.Priority,
            Deadline = input.Deadline,
        });
    }
}
