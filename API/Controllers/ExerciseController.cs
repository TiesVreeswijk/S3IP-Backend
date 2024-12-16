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

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        var exercises = await _context.Exercise.ToListAsync();
        
        return Ok(exercises);
    }
}
}