namespace StudentServices
{
    public class StudentsService : IStudentsService
    {
        public string GetName()
        {
            return "Sachin";
        }

        public int GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}
