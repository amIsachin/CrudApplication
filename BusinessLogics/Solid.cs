using System;

namespace BusinessLogics
{
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
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1001, 10000001);
        }
    }
}
