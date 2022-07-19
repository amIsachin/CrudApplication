using StudentServices;
using System;
using System.Linq;

namespace BusinessLogics
{
    /// <summary>
    /// **Please dont touch this line of code this line of code direct affected by entire application.
    /// /// Here is only common variables which is use whole application.
    /// </summary>
    public sealed class CommonVariables
    {
        public static bool AlertMessage = true;
    }

    /// <summary>
    /// **Please dont touch this line of code this line of code direct affected by entire application.
    /// Here is only common properties which is use whole application.
    /// </summary>
    public sealed class CommonProperties
    {
        public static DateTime GetTime { get; private set; } = DateTime.Now;
    }

    /// <summary>
    /// **Please dont touch this line of code this line of code direct affected by entire application.
    /// Here is only common methods which is use whole application.
    /// </summary>
    public sealed class CommonMethods
    {
        #region InitailizeDependencyInjectionInstance
        private readonly IStudentsService _StudentsService = null;
        public CommonMethods(IStudentsService studentsService)
        {
            _StudentsService = studentsService;
        }
        #endregion

        public int GenerateRandomNumber()
        {
        ReEvaluate:
            Random random = new Random();
            int newRandomNumber = random.Next(1001, 10000001);
            var isExist = _StudentsService.GetAllStudents().FirstOrDefault(x => x.ID == newRandomNumber);
            if (isExist == null)
            {
                return newRandomNumber;
            }
            else
            {
                goto ReEvaluate;
            }
        }

        public static bool SuspendCurrentExecutionEnvironment(int testedValue)
        {
            if (testedValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsGenderValid(string gender)
        {
            switch (gender.ToLower())
            {
                case "male":
                    return true;
                case "female":
                    return true;
                case "-1":
                    return false;
                default:
                    return false;

            }
        }

        public static string IsAvailable(string email, string number)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                email = null;
                return email;
            }
            else
            {
                number = null;
                return number;
            }
        }

    }
}
