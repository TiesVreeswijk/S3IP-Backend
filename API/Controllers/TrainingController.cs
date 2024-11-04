using System.IdentityModel.Tokens.Jwt;
using Business.Entities;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business;
using Business.Dtos.RequestDtos;
using Business.Exceptions;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ITrainingService _trainingService;

        public TrainingController(MyDbContext context, ITrainingService trainingService)
        {
            _context = context;
            _trainingService = trainingService;
        }

        [Authorize]
        [HttpPost("protected")]
        public async Task<IActionResult> Protected()
        {
            var training = new Training
            {
                Name = "Protected Training"
            };
            try
            {
                _context.training.Add(training);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating training: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                return StatusCode(500, "An error occurred while saving the training. Please try again later.");
            }
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult Create([FromBody] TrainingReq request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            request.UserId = userId;
            
            try
            {
                _trainingService.CreateTraining(request);
                return Ok();
            }
            catch (RegistrationException e) { return BadRequest(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
    }
}