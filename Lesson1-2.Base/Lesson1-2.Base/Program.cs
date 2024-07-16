using System;
using System.Globalization;

namespace Lesson1_2.Base
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "5dfsadfsda sdafsda";

            int a;

            int.TryParse(str, out a);
            Console.WriteLine(a);

            //try
            //{
            //    int a = Convert.ToInt32(str);
            //    Console.WriteLine("Успешная конвертация");
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Ошибка конвертации");
            //}

            //NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            //{
            //    NumberDecimalSeparator = ".",
            //};


            //double a = double.Parse(str, numberFormatInfo);
            //Console.WriteLine(a);
        }





    }
}


