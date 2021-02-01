using System;
using System.ComponentModel.DataAnnotations;

namespace LushNailBar.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public Nullable<int> SortByType { get; set; }
        public string ServicePrice { get; set; }
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
    }
}