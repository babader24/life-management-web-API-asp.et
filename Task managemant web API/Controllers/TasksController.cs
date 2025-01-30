using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_managemant_web_API.DTOs;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;
namespace Task_managemant_web_API.Controllers
{
	[Route("api/Tasks")]
	[ApiController]
	public class TasksController : ControllerBase
	{

		private readonly IRepository<Tasks> _Tasksrepository;

		// GET: api/<TasksController>
		[HttpGet]
		public async Task<IActionResult> Tasks()
		{
			var tasks = await _Tasksrepository.GetAllAsync();

			return Ok(tasks);
		}

		// GET api/<TasksController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTaskById(int id)
		{
			if (id < 0)
			{
				return BadRequest($"Not Accepted ID {id}");
			}

			var tasks = await _Tasksrepository.GetByIdAsync(id);

			if (tasks == null)
			{
				return NotFound($"The task With ID: {id} Not Found");

			}
			return Ok(tasks);
		}

		// POST api/<TasksController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TasksDto tasksDto)
		{
			var tasks = new Tasks()
			{
				
				TaskDescription = tasksDto.TaskDescription,
				IsDone = tasksDto.IsDone,
				PriorityId = tasksDto.PriorityId,
				DayId = tasksDto.DayId,
				UserID = tasksDto.UserID				
			};
			var createdTasksResponse = await _Tasksrepository.AddAsync(tasks);
			return CreatedAtAction(nameof(GetTaskById), new { Id = createdTasksResponse.Id }, createdTasksResponse);
			
		}

		// PUT api/<TasksController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] TasksDto tasksDto)
		{
			var TaskEntity  = await _Tasksrepository.GetByIdAsync(id);
			if(TaskEntity == null)
			{
				return NotFound();
			}
			TaskEntity.TaskDescription = tasksDto.TaskDescription;
			TaskEntity.PriorityId = tasksDto.PriorityId;
			TaskEntity.DayId = tasksDto.DayId;
			TaskEntity.IsDone = tasksDto.IsDone;

			await _Tasksrepository.UpdateAsync(TaskEntity);
			return NoContent();
		}

		// DELETE api/<TasksController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var TaskEntity = await _Tasksrepository.GetByIdAsync(id);
			if (TaskEntity == null)
			{
				return NotFound();
			}
			await _Tasksrepository.DeleteAsync(TaskEntity);
			return NoContent();
		}
	}
}
