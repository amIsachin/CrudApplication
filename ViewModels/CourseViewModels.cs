using BusinessEntity;
using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class CourseBindingViewModelPagination
    {
        public List<CourseEntity> Course { get; set; }
        public int PageNumber { get; set; }
        public string Clicked { get; set; }
    }
}
