using System;

namespace BusinessEntity
{
    public interface IBaseEntity
    {
        int ID { get; set; }  //--> protected.
        DateTime CreatedOn { get; set; } //--> = DateTime.Now;  //--> Protected , set private
    }
}
