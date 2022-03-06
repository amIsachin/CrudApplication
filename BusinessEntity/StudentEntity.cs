namespace BusinessEntity
{
    public sealed class StudentEntity : BaseEntity
    {
        public void Print()
        {
            base.ID = 10;
        }
    }

    public class ABC
    {
        public void Print()
        {
            BaseEntity b = new BaseEntity();
            b.ID = 110;
        }
    }
}
