using System;
using Microsoft.AspNetCore.Mvc;
using ServiceRequests.Application;
using ServiceRequests.Api;
using System.Linq;

namespace ServiceRequests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestsStore _serviceRequestsStore;

        public ServiceRequestsController(IServiceRequestsStore serviceRequestsStore)
        {
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
        public IActionResult GetById(Guid id)
        {
            var serviceRequest = _serviceRequestsStore.GetById(id);

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
                Id = Guid.NewGuid(),
                BuildingCode = body.BuildingCode,
                CreatedBy = body.CreatedBy,
                CreatedDate = body.CreatedDate.Value,
                CurrentStatus = body.CurrentStatus.Value,
                Description = body.Description,
                LastModifiedBy = body.LastModifiedBy,
                LastUpdatedBy = body.LastUpdatedBy.Value
            };
            
            _serviceRequestsStore.Create(serviceRequest);
            
            return CreatedAtAction(nameof(Post), new { id = serviceRequest.Id }, serviceRequest);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(Guid id, [FromBody] ServiceRequestBody body)
        {
            if (_serviceRequestsStore.GetById(id) == null)
            {
                return NotFound();
            }

            var serviceRequest = new ServiceRequest
            {
                Id = id,
                BuildingCode = body.BuildingCode,
                CreatedBy = body.CreatedBy,
                CreatedDate = body.CreatedDate.Value,
                CurrentStatus = body.CurrentStatus.Value,
                Description = body.Description,
                LastModifiedBy = body.LastModifiedBy,
                LastUpdatedBy = body.LastUpdatedBy.Value
            };

            _serviceRequestsStore.Update(id, serviceRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            if (_serviceRequestsStore.GetById(id) == null)
            {
                return NotFound();
            }

            _serviceRequestsStore.Delete(id);
            return NoContent();
        }
    }
}
