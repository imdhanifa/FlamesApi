using CSIT.Flames.Api.DTO;
using CSIT.Flames.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSIT.Flames.Api.Flames;

namespace CSIT.Flames.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlamesController : ControllerBase
    {

        private readonly IFlames _flames;
        private readonly ILogger<FlamesController> _logger;

        public FlamesController(ILogger<FlamesController> logger, IFlames flames)
        {
            _logger = logger;
            _flames = flames;
        }

        
        [HttpPost("search")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
           
            string Message = await _flames.check(person);
            return Ok(Message);
        }
    }
}
