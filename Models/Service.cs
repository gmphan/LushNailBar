using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LushNailBar.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Service Name")]
        [Required]
        public string ServiceName { get; set; }

        [DisplayName("Service Type")]
        [Required]
        public string ServiceType { get; set; }

        [DisplayName("Sort By Type")]
        public Nullable<int> SortByType { get; set; }

        [DisplayName("Service Price")]
        [Required]
        public string ServicePrice { get; set; }

        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}