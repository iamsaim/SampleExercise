using People.Service.DTO;
using People.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace People.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {

        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(Guid id)
        {
            return Ok(_peopleService.GetPerson(id));
        }

        [HttpGet("")]
        public IActionResult GetPersons()
        {
            return Ok(_peopleService.GetPersons());
        }

        [HttpPost("")]
        public IActionResult AddJob(PeopleDTO job)
        {
            _peopleService.AddPeople(job);
            return Ok();
        }
    }
}