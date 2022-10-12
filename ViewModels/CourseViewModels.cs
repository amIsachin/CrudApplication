using BusinessEntity;
using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class CourseBindingViewModelPagination
    {
        //public int ID { get; set; }
        //public string CourseName { get; set; }
        //public int PageNumber { get; set; }
        //public int StudentID { get; set; }
        //public DateTime CreatedOn { get; set; } = DateTime.Now;

        public List<CourseEntity> Course { get; set; }
        public int PageNumber { get; set; }
        public string Clicked { get; set; }
    }
}
