using Business.Entities;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API
{ 
    [ApiController]
    [Route("[controller]")]

public class ExercisesController : ControllerBase
{
    private readonly MyDbContext _context;

    public ExercisesController(MyDbContext context)
    {
        _context = context;
    }

    // GET: api/exercises
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        var exercises = await _context.Exercise.ToListAsync();

        // Optionally, map to DTOs if you want to send less data to the client
        return Ok(exercises);
    }
}
}