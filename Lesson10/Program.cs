using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;

            a = ++a * a;
            
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
