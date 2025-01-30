using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_managemant_web_API.DTOs;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;

namespace Task_managemant_web_API.Controllers
{
	[Route("api/NoteBook")]
	[ApiController]
	public class NoteBookController : ControllerBase
	{

		private readonly IRepository<NoteBook> _NoteBookRepository;

        public NoteBookController(IRepository<NoteBook> NoteBookRepository)
        {
            _NoteBookRepository = NoteBookRepository;
        }

		[HttpGet]

		public  async Task<IActionResult> NoteBooks()
		{
			var NoteBooks = await _NoteBookRepository.GetAllAsync();

			return Ok(NoteBooks);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult>GetNoteBookByID(int id)
		{
			if (id < 0)
			{
				return BadRequest($"Not Accepted ID {id}");
			}

			var NoteBooks = await _NoteBookRepository.GetByIdAsync(id);

			if(NoteBooks == null)
			{
				return NotFound($"The NoteBook With ID: {id} Not Found");
				
			}
			return Ok(NoteBooks);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]  NoteBook noteBook)
		{
			var NoteBookEntity = new NoteBook()
			{
				Id = noteBook.Id,
				NoteBookTitle = noteBook.NoteBookTitle,
				NoteBookDescription = noteBook.NoteBookDescription,
				UserID = noteBook.UserID
			};
			var createdNotebookResponse = await _NoteBookRepository.AddAsync(NoteBookEntity);
			return CreatedAtAction(nameof(GetNoteBookByID), new { Id = createdNotebookResponse.Id }, createdNotebookResponse);

		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody]  NoteBook noteBook)
		{
			var NoteBooksEntity = await _NoteBookRepository.GetByIdAsync(id);
			if(NoteBooksEntity == null)
			{
				return NotFound();
			}
			NoteBooksEntity.NoteBookDescription = noteBook.NoteBookDescription;
			NoteBooksEntity.NoteBookTitle = noteBook.NoteBookTitle;
			await _NoteBookRepository.UpdateAsync(NoteBooksEntity);
			return NoContent();

		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var NoteBooks = await _NoteBookRepository.GetByIdAsync(id);
			if (NoteBooks == null)
			{
				return NotFound();
			}
			await _NoteBookRepository.DeleteAsync(NoteBooks);
			return NoContent();

		}
	}
}
