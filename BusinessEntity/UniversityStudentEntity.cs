namespace BusinessEntity
{
    public class UniversityStudentEntity : BaseEntity
    {
        public int EnrolmentNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public string City { get; set; }
        public string Document { get; set; }
        public string Image{ get; set; }
    }
}
