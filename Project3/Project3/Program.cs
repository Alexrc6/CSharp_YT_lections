using System;
using System.Globalization;

namespace Lesson1_2.Base
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int sum = a + b + c;
            int prod = a * b * c;
            Console.WriteLine($"{sum} ,{prod} ");
            Console.ReadLine();
        }





    }
}


