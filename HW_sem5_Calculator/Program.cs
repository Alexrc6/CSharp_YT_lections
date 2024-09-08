/*Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле 
    так чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена или введёт пустую строку.*/

namespace HW_sem5_Calculator
{
    internal class Program
    {
        static void CheckSignAndDo(ICalc calc, char sign, double num)
        {

            switch (sign)
            {
                case '+': calc.Add(num); break;
                case '-': calc.Substract(num); break;
                case '*': calc.Multiply(num); break;
                case '/': calc.Divide(num); break;
                case '<': calc.ClearLast(); break;
                default: Console.WriteLine("Некорректный ввод"); break;
            }
        }

        static bool CalculationRes(ICalc calc, string signAndValue, Predicate<char> checkSpace, Action<char, double> checkSignAndCalc)
        {
            if (string.IsNullOrEmpty(signAndValue))
                return false;

            char sign = (char)signAndValue[0];
            if (checkSpace(sign))
            {
                Console.WriteLine("Расчет окончен.");
                return false;
            }

            if (sign == '<')
            {
                calc.ClearLast();
                return true;
            }    
           
            if (double.TryParse(signAndValue.Substring(1), out double num))
            {
                checkSignAndCalc(sign, num);
                return true;
            }
            return false;
        }

        static void Calculator_GotResult(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"result = {((Calculator)sender).resStack.Peek()}");
        }
        static void Calculator_Request(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("введите следующее действие, используя знаки +, -, *, /, < (< - возврат действия) и числа, например: +5 или /6. Пробел закончит вычисления ");
        }

        static void Main(string[] args)
        {
            ICalc calc = new Calculator();
            calc.GotResult += Calculator_GotResult;
            calc.GotResult += Calculator_Request;

            calc.AddFirsrNum();

            bool flag = true;
            while (flag)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                flag = CalculationRes(calc, input, x => x == ' ', (sign, num) => CheckSignAndDo(calc, sign, num));

            }
        }
    }
}
