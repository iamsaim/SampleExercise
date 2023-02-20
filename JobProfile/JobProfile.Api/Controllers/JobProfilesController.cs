using JobProfile.Service.DTO;
using JobProfile.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobProfile.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobProfilesController : ControllerBase
    {

        private readonly ILogger<JobProfilesController> _logger;
        private readonly IJobService _jobService;

        public JobProfilesController(ILogger<JobProfilesController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(Guid id)
        {
            return Ok(_jobService.GetJob(id));
        }

        [HttpGet("")]
        public IActionResult GetAllJobs()
        {
            return Ok(_jobService.GetAllJob());
        }

        [HttpPost("")]
        public IActionResult AddJob(JobDTO job)
        {
            _jobService.AddJob(job);
            return Ok();
        }
    }
}