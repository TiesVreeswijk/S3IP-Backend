// File: API/Controllers/TrainingController.cs

using System.IdentityModel.Tokens.Jwt;
using Business.Entities;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business.Dtos.RequestDtos;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TrainingController(MyDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("create")]
        
        public async Task<IActionResult> Create([FromBody] TrainingReq request)
        {

            var training = new Training
            {
                UserId = request.UserId,
                Name = request.NewTrainingName,
                TimeCompleted = request.TimeCompleted
            };

            try
            {
                _context.Training.Add(training);
                await _context.SaveChangesAsync();

                // Retrieve the newly added training to verify
                var addedTraining = await _context.Training.FindAsync(training.TrainingId);
                if (addedTraining == null)
                {
                    return StatusCode(500, "Training was not added successfully.");
                }

                return Ok(addedTraining);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating training: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                return StatusCode(500, "An error occurred while saving the training. Please try again later.");
            }

            
        }
    }
}