﻿using StudentServices;
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
        private readonly IStudentsService _StudentsService = null;
        public CommonMethods(IStudentsService studentsService)
        {
            _StudentsService = studentsService;
        }

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

    }
}
