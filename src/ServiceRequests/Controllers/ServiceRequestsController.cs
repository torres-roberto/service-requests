using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceRequests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ILogger<ServiceRequestsController> _logger;

        public ServiceRequestsController(ILogger<ServiceRequestsController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<ServiceRequest> Get()
        {
            var rng = new Random();
            return new List<ServiceRequest>
            {
                new ServiceRequest()
            };
        }
    }
}
