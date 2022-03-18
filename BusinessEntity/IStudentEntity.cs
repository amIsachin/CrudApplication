using System;

namespace BusinessEntity
{
    public interface IStudentEntity
    {
        int RollNumber { get; set; }
        string Name { get; set; }
        string Class { get; set; }
        string Gender { get; set; }
        int Age { get; set; }
        decimal Fees { get; set; }
        string City { get; set; }
        string Address { get; set; }
        DateTime AdmissionSession { get; set; }
    }
}
