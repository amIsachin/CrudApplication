using System;

namespace BusinessEntity
{
    public class BaseEntity
    {
        protected internal int ID { get; set; }
        protected internal DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
