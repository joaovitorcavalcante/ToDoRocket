using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application;
using ToDo.Application.UseCases.Tasks.Create;
using ToDo.Application.UseCases.Tasks.Delete;
using ToDo.Application.UseCases.Tasks.GetAll;
using ToDo.Application.UseCases.Tasks.GetById;
using ToDo.Application.UseCases.Tasks.Update;
using ToDo.Communication.Requests;
using ToDo.Communication.Responses;

namespace ToDo.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ToDoDB _db;

    public TaskController(ToDoDB db)
    {
        _db = db;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] CreateTaskRequest request)
    {
        var useCase = new CreateTaskUseCase(_db);

        useCase.Execute(request);

        return Created();
    }

    [HttpGet]
    [ProducesResponseType(typeof(TaskListResponse), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var result = new GetAllTasksUseCase(_db).Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{taskId}")]
    [ProducesResponseType(typeof(TaskListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int taskId)
    {
        var useCase = new GetTaskByIdUseCase(_db);
        var result = useCase.Execute(taskId);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPut]
    [Route("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(
        [FromRoute] int taskId, 
        [FromBody] UpdateTaskRequest request)
    {
        var useCase = new UpdateTaskById(_db);
        useCase.Execute(taskId, request);

        return NoContent();
    }

    [HttpPatch]
    [Route("{taskId}/completed")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult TaskCompleted([FromRoute] int taskId)
    {
        return NoContent();
    }

    [HttpDelete]
    [Route("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] int taskId) 
    { 
        var useCase = new DeleteTaskByIdUseCase(_db);
        useCase.Execute(taskId);

        return NoContent();
    }
}
