using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceRequests.Api
{
    public class ServiceRequestBody
    {
        [Required]
        public string BuildingCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public CurrentStatus? CurrentStatus { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string LastModifiedBy { get; set; }
        [Required]
        public DateTime? LastUpdatedBy { get; set; }
    }  
}