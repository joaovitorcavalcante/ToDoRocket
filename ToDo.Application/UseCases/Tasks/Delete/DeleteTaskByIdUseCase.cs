namespace ToDo.Application.UseCases.Tasks.Delete;
public class DeleteTaskByIdUseCase
{
    private readonly ToDoDB _db;

    public DeleteTaskByIdUseCase(ToDoDB db)
    {
        _db = db;
    }

    public void Execute(int taskId)
    {
        var taskIndex = _db.Tasks.FindIndex(t => t.Id == taskId);
        _db.Tasks.RemoveAt(taskIndex);
    }
}
