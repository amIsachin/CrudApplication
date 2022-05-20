using BusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class StudentEntityBindingViewModel : SEO
    {
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int RollNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Class { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Gender { get; set; }
        [Required]
        [Range(minimum: 18, maximum: 40)]
        public int Age { get; set; }
        [Required]
        [Range(minimum: 400, maximum: 1200)]
        public decimal Fees { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Address { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime AdmissionSession { get; set; }
    }

    public class StudentEntityListBindingViewModel : SEO
    {
        public List<StudentEntity> Students { get; set; }
    }
}