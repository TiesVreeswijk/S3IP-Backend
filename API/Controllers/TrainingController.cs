using System.IdentityModel.Tokens.Jwt;
using Business.Entities;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business;
using Business.Dtos.EntityDtos;
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
        [HttpGet]
        public List<Training> GetTrainingsByUserId()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            List<Training> trainings = _trainingService.GetTrainingsByUserId(userId);
            return trainings;
        }

        [AllowAnonymous]
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
        
        [Authorize]
        [HttpPost("addExercise")]
        public IActionResult AddExercise([FromBody] TrainingExerciseReq request)
        {
            
            try
            {
                _trainingService.AddExercise(request);
                return Ok();
            }
            catch (RegistrationException e) { return BadRequest(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
        
        
        [HttpGet("getTrainingById")]
        public IActionResult GetTrainingById([FromQuery] int id)
        {
            try
            {
                List<TrainingExerciseDto> exercises = _trainingService.getTrainingExercisesById(id);
                return Ok(exercises);
            }
            catch (RegistrationException e) { return BadRequest(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
    }
}