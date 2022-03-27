using System;

namespace BusinessLogics
{
    /// <summary>
    /// **Please dont touch this line of code this line of code direct affected by entire application.
    /// </summary>
    public sealed class RandomNumber
    {
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1001, 10000001);
        }
    }
}
