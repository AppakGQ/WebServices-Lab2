using Microsoft.AspNetCore.Mvc;
using TaskListApi.Models;

namespace TaskListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    // Хранение данных в памяти — согласно условию лабораторной работы
    // база данных не используется.
    private static readonly List<TaskItem> Tasks = new();
    private static int _nextId = 1;

    /// <summary>
    /// Получить список всех задач.
    /// GET /api/tasks
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll()
    {
        return Ok(Tasks);
    }

    /// <summary>
    /// Получить задачу по идентификатору.
    /// GET /api/tasks/{id}
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    /// <summary>
    /// Добавить новую задачу.
    /// POST /api/tasks
    /// </summary>
    [HttpPost]
    public ActionResult<TaskItem> Create([FromBody] TaskItem newTask)
    {
        if (newTask == null || string.IsNullOrWhiteSpace(newTask.Title))
        {
            return BadRequest("Поле \"Title\" обязательно для заполнения.");
        }

        newTask.Id = _nextId++;
        Tasks.Add(newTask);

        return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
    }

    /// <summary>
    /// Изменить существующую задачу.
    /// PUT /api/tasks/{id}
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<TaskItem> Update(int id, [FromBody] TaskItem updatedTask)
    {
        if (updatedTask == null || string.IsNullOrWhiteSpace(updatedTask.Title))
        {
            return BadRequest("Поле \"Title\" обязательно для заполнения.");
        }

        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        return Ok(task);
    }

    /// <summary>
    /// Удалить задачу по идентификатору.
    /// DELETE /api/tasks/{id}
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        Tasks.Remove(task);
        return Ok();
    }
}
