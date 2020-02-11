using System;
using System.Collections.Generic;

namespace ServiceRequests.Application
{
    public class ServiceRequestsStore : IServiceRequestsStore
    {
        private readonly IDictionary<Guid, ServiceRequest> _serviceRequests = new Dictionary<Guid, ServiceRequest>();

        public IEnumerable<ServiceRequest> GetAll()
        {
            return _serviceRequests.Values;
        }

        public ServiceRequest GetById(Guid id)
        {
            _serviceRequests.TryGetValue(id, out var serviceRequest);
            return serviceRequest;
        }

        public void Create(ServiceRequest serviceRequest)
        {
            _serviceRequests.TryAdd(serviceRequest.Id, serviceRequest);
        }
    }
}