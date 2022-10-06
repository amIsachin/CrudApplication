using System;

namespace ViewModels
{
    public class CourseBindingViewModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public int PageNumber { get; set; }
        public int StudentID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
