using System;
using System.Globalization;
System.Globalization;

namespace Lesson1_2.Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "5.9";

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            double a = double.Parse(str, numberFormatInfo);

#error version
        }
    }
}
