using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using DAL.DataAccess;

namespace Common.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentController : ControllerBase
	{
		private readonly ILogger<StudentController> _logger;
		private readonly Context _context;

		public StudentController(ILogger<StudentController> logger, Context context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet(Name = "GetStudents")]
		public IEnumerable<Student> Get()
		{
			return _context.Students.ToList();
		}

		[HttpPost()]
		public async Task<ActionResult> AddStudentAsync(Student student)
		{
			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteStudentAsync(int id)
		{
			Student? student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}

			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}