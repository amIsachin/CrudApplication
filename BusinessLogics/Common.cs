using System;

namespace BusinessLogics
{
    public static class Common
    {
        public static int RollNo;
        static Common()
        {
            RollNo = 1000;
        }

        public static int Get()
        {
            return ++RollNo;
        }
    }

    public static class CommonFunction
    {
        public static int RollNo = 1000;
        public static int GetRollNo()
        {
            return ++RollNo;
        }
    }
}