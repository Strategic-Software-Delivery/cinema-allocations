using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaAllocations.Infra.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieScreeningController : ControllerBase
    {
        private readonly ILogger<MovieScreeningController> _logger;

        public MovieScreeningController(ILogger<MovieScreeningController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AllocateSeats([FromQuery] string showId, [FromQuery] int partyRequested)
        {
            throw new NotImplementedException();
        }
    }
}