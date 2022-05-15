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
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime AdmissionSession { get; set; }
    }

    public class StudentEntityListBindingViewModel : SEO
    {
        public List<StudentEntity> Students { get; set; }
    }
}
