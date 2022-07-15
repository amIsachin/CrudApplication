using System;

namespace BusinessEntity
{
    public class CourseEntity : BaseEntity/*, IEquatable<CourseEntity>*/
    {
        public string Name { get; set; }
        public int StudentID { get; set; }

        //public bool Equals(CourseEntity other)
        //{
        //    if (object.ReferenceEquals(other,null))
        //    {
        //        return false;
        //    }

        //    if (object.ReferenceEquals(this, other))
        //    {
        //        return true;
        //    }

        //    return ID.Equals(other.ID) && Name.Equals(other.Name) && StudentID.Equals(other.StudentID)
        //        && CreatedOn.Equals(other.CreatedOn);
        //}

        //public override int GetHashCode()
        //{
        //    int idHashCode = ID.GetHashCode();
        //    int nameHashCode = Name.GetHashCode();
        //    int studentIDHashCode = StudentID.GetHashCode();
        //    int createdOnHashCode = CreatedOn.GetHashCode();

        //    return idHashCode ^ nameHashCode ^ studentIDHashCode ^ createdOnHashCode;
        //}
    }
}
