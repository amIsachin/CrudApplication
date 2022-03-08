using System;

namespace BusinessEntity
{
    public class BaseEntity
    {
        protected int ID { get; set; }
        protected DateTime CreatedOn { get; private set; } = DateTime.Now;
    }
}
