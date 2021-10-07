using System;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models;

namespace WebApplication1.Models
{
    public class ServiceRequest : IEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string BuildingCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public CurrentStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
