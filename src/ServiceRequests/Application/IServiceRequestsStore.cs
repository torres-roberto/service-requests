using System;
using System.Collections.Generic;

namespace ServiceRequests.Application
{
    public interface IServiceRequestsStore
    {
        IEnumerable<ServiceRequest> GetAll();
        ServiceRequest GetById(Guid id);
        void Create(ServiceRequest serviceRequest);
        void Update(Guid id, ServiceRequest serviceRequest);
        void Delete(Guid id);
    }
}