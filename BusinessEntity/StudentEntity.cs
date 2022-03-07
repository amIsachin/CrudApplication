using System;

namespace BusinessEntity
{
    public sealed class StudentEntity : BaseEntity
    {
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
}