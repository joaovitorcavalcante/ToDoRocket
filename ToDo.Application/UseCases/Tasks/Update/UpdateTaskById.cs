using ToDo.Application.Enums;
using ToDo.Communication.Requests;

namespace ToDo.Application.UseCases.Tasks.Update;

public class UpdateTaskById
{
    private readonly ToDoDB _db;

    public UpdateTaskById(ToDoDB db)
    {
        _db = db;
    }

    public void Execute(int taskId, UpdateTaskRequest input)
    {
        var taskIndex = _db.Tasks.FindIndex(t => t.Id == taskId);

        if (taskIndex != -1)
        {
            _db.Tasks[taskIndex].Name = input.Name;
            _db.Tasks[taskIndex].Description = input.Description;
            _db.Tasks[taskIndex].Priority = (Priority) input.Priority;
            _db.Tasks[taskIndex].Deadline = input.Deadline;
        }
    }
}
