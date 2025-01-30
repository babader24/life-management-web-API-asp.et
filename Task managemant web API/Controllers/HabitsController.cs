using Microsoft.AspNetCore.Mvc;
using System;
using Task_managemant_web_API.DTOs;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_managemant_web_API.Controllers
{
	[Route("api/Habits")]
	[ApiController]
	public class HabitsController : ControllerBase
	{
		private readonly IRepository<Habit> _habitRepository;

        public HabitsController(IRepository<Habit> habitRepository)
        {
			_habitRepository = habitRepository;
		}




        // GET: api/<HabitsController>
        [HttpGet]
		public async Task<IActionResult> Habits()
		{
			var Habits = await _habitRepository.GetAllAsync();
			return Ok(Habits);
		}

		// GET api/<HabitsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetHabitById(int id)
		{
			if (id < 0 )
			{
				return BadRequest();
			}
			var Habit = await _habitRepository.GetByIdAsync(id);
			if (Habit == null)
			{
				return NotFound();
			}
			return Ok(Habit);
		}

		// POST api/<HabitsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] HabitDto habitDto)
		{
			var habitEntity = new Habit()
			{
				HabitName = habitDto.HabitName,
				Sat = habitDto.Sat,
				Sun = habitDto.Sun,
				Mon = habitDto.Mon,
				Tue = habitDto.Tue,
				Wed = habitDto.Wed,
				Thu = habitDto.Thu,
				Fri = habitDto.Fri,
				UserId = habitDto.UserId,
			};
			var createHabitResponse = await _habitRepository.AddAsync(habitEntity);
			return CreatedAtAction(nameof(GetHabitById), new { Id = createHabitResponse.Id }, createHabitResponse);
		}

		// PUT api/<HabitsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] HabitDto habitDto)
		{
			var habit = await _habitRepository.GetByIdAsync(id);
			if (habit == null)
			{
				return NotFound();
			}
			habit.HabitName = habitDto.HabitName;
			habit.Sat = habitDto.Sat;
			habit.Sun = habitDto.Sun;
			habit.Mon = habitDto.Mon;
			habit.Tue = habitDto.Tue;
			habit.Wed = habitDto.Wed;
			habit.Thu = habitDto.Thu;
			habit.Fri = habitDto.Fri;
			habit.UserId = habitDto.UserId;

			await _habitRepository.UpdateAsync(habit);
			return NoContent();
		}

		// DELETE api/<HabitsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var habit = await _habitRepository.GetByIdAsync(id);
			if (habit == null)
			{
				return NotFound();
			}
			await _habitRepository.DeleteAsync(habit);
			return NoContent();
		}
	}
}
