using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_managemant_web_API.DTOs;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;

namespace Task_managemant_web_API.Controllers
{
	[Route("api/StickyNote")]
	[ApiController]
	public class StickyNotesController : ControllerBase
	{
		private readonly  IRepository<StickyNote> _StickyNoteRepository;

        public StickyNotesController(IRepository<StickyNote> StickyNoteRepository)
        {
            _StickyNoteRepository = StickyNoteRepository;
        }

		[HttpGet]
		public async Task<IActionResult>StickyNotes()
		{
			var StickyNotes = await _StickyNoteRepository.GetAllAsync();
			return Ok(StickyNotes);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetStickyNoteById(int id)
		{
			if (id < 0) 
			{
				return BadRequest($"Not Accepted ID {id}");
			}
			var StickyNote = await _StickyNoteRepository.GetByIdAsync(id);
			if (StickyNote != null)
			{
				return Ok(StickyNote);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] StickyNoteDto newStickyNote)
		{
			var Sticky = new StickyNote()
			{
				NoteDescription = newStickyNote.NoteDescription,
				ColorID = newStickyNote.ColorID,
				UserID = newStickyNote.UserID,
				CreatedAt = newStickyNote.CreatedAt,
			};
			var createStickyResponse = await _StickyNoteRepository.AddAsync(Sticky);
			return CreatedAtAction(nameof(GetStickyNoteById), new {Id = createStickyResponse.Id}, createStickyResponse);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] StickyNoteDto newStickyNote)
		{
			var Sticky = await _StickyNoteRepository.GetByIdAsync(id);
			if(Sticky == null)
			{
				return NotFound();
			}
			Sticky.NoteDescription = newStickyNote.NoteDescription;
			Sticky.ColorID = newStickyNote.ColorID;
			Sticky.UserID = newStickyNote.UserID;
			
			await _StickyNoteRepository.UpdateAsync(Sticky);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, [FromBody] StickyNoteDto newStickyNote)
		{
			var Sticky = await _StickyNoteRepository.GetByIdAsync(id);
			if (Sticky == null)
			{
				return NotFound();
			}
		

			await _StickyNoteRepository.DeleteAsync(Sticky);
			return NoContent();
		}

	}
}
