using BusinessEntity;
using System.Collections.Generic;

namespace ServicePrincipals
{
    public class CourseEntityComparer : IEqualityComparer<CourseEntity>
    {
        public bool Equals(CourseEntity x, CourseEntity y)
        {
            return x.ID.Equals(y.ID) && x.Name.Equals(y.Name) && x.StudentID.Equals(y.StudentID) &&
                x.CreatedOn.Equals(y.CreatedOn);
        }

        public int GetHashCode(CourseEntity obj)
        {
            int idHashCode = obj.ID.GetHashCode();
            int nameHashCode = obj.Name.GetHashCode();
            int studentIDHashCode = obj.StudentID.GetHashCode();
            int createdOnHashCode = obj.CreatedOn.GetHashCode();

            return idHashCode ^ nameHashCode ^ studentIDHashCode ^ createdOnHashCode;
        }
    }
}
