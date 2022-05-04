using BusinessEntity;
using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class StudentEntityBindingViewModel : SEO
    {
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Fees { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime AdmissionSession { get; set; }
    }

    public class StudentEntityListBindingViewModel : SEO
    {
        public List<StudentEntity> Students { get; set; }
    }
}
