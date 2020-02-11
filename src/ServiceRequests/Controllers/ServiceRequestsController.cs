using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceRequests.Application;
using ServiceRequests.Api;
using System.Linq;

namespace ServiceRequests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ILogger<ServiceRequestsController> _logger;
        private readonly IServiceRequestsStore _serviceRequestsStore;

        public ServiceRequestsController(
            ILogger<ServiceRequestsController> logger,
            IServiceRequestsStore serviceRequestsStore
        )
        {
            _logger = logger;
            _serviceRequestsStore = serviceRequestsStore;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult Get()
        {
            var serviceRequests = _serviceRequestsStore.GetAll();

            if (!serviceRequests.Any())
            {
                return NoContent();
            }

            return Ok(serviceRequests);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(string id)
        {
            var serviceRequest = _serviceRequestsStore.GetById(Guid.Parse(id));

            if (serviceRequest == null)
            {
                return NotFound();
            }
            
            return Ok(serviceRequest);
        }

        [HttpPost()]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post(ServiceRequestBody body)
        {
            var serviceRequest = new ServiceRequest
            {
              Id = Guid.NewGuid()                  
            };
            
            _serviceRequestsStore.Create(serviceRequest);
            
            return CreatedAtAction(nameof(GetById), new { id = serviceRequest.Id }, serviceRequest);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(ServiceRequestBody body)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public IActionResult Delete(string id)
        {
            return NoContent();
        }
    }
}
