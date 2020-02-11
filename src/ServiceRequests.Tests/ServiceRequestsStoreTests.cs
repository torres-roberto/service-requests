using System;
using System.Linq;
using ServiceRequests.Application;
using Xunit;

namespace ServiceRequests.Tests
{
    public class ServiceRequestsStoreTests
    {
        private ServiceRequestsStore _serviceRequestsStore;
        public ServiceRequestsStoreTests()
        {
            _serviceRequestsStore = new ServiceRequestsStore();
        }

        [Fact]
        public void ShouldGetIdFromStore()
        {
            // Arrange
            var serviceRequest = new ServiceRequest()
            {
                Id = Guid.NewGuid()
            };

            _serviceRequestsStore.Create(serviceRequest);

            // Act
            var result = _serviceRequestsStore.GetById(serviceRequest.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceRequest.Id, result.Id);
        }

        [Fact]
        public void ShouldGetAllFromStore()
        {
            // Arrange
            var serviceRequest1 = new ServiceRequest()
            {
                Id = Guid.NewGuid()
            };

            var serviceRequest2 = new ServiceRequest()
            {
                Id = Guid.NewGuid()
            };

            var serviceRequest3 = new ServiceRequest()
            {
                Id = Guid.NewGuid()
            };

            _serviceRequestsStore.Create(serviceRequest1);
            _serviceRequestsStore.Create(serviceRequest2);
            _serviceRequestsStore.Create(serviceRequest3);

            // Act
            var result = _serviceRequestsStore.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void ShouldUpdateIdInStore()
        {
            // Arrange
            var serviceRequest = new ServiceRequest()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "Very First Building Code"
            };

            _serviceRequestsStore.Create(serviceRequest);

            // Act
            var updatedServiceRequest = new ServiceRequest
            {
                Id = serviceRequest.Id,
                BuildingCode = "Updated Building Code"
            };

            _serviceRequestsStore.Update(serviceRequest.Id, updatedServiceRequest);

            // Assert
            var result = _serviceRequestsStore.GetById(serviceRequest.Id);

            Assert.NotNull(result);
            Assert.Equal(serviceRequest.Id, result.Id);
            Assert.Equal(updatedServiceRequest.BuildingCode, result.BuildingCode);
        }

        [Fact]
        public void ShouldDeleteIdInStore()
        {
            // Arrange
            var serviceRequest = new ServiceRequest()
            {
                Id = Guid.NewGuid()
            };

            _serviceRequestsStore.Create(serviceRequest);

            // Act
            _serviceRequestsStore.Delete(serviceRequest.Id);

            // Assert
            var remainingServiceRequests = _serviceRequestsStore.GetAll();
            Assert.NotNull(remainingServiceRequests);
            Assert.Equal(0, remainingServiceRequests.Count());
        }
    }
}
