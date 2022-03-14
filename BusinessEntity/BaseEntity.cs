using System;

namespace BusinessEntity
{
    public class BaseEntity
    {
        public int ID { get; set; }  //--> protected.
        public DateTime CreatedOn { get; set; } = DateTime.Now;  //--> Protected , set private
    }
}
