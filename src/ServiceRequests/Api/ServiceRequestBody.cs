using System;

namespace ServiceRequests.Api
{
    public class ServiceRequestBody
    {
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastUpdatedBy { get; set; }
    }  
}