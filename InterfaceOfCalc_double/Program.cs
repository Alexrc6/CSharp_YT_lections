//Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. (возможно стоит задействовать перегрузку операций).

namespace InterfaceOfCalc
{
    internal class Program
    {

        static void Execute(Action<double> action, double value = 10)
        {
            try
            {
                Console.WriteLine($"Выполнение операции с аргументом: {value}");
                action.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
            catch (CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Calculator_GotResult3(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"result = {((Calculator)sendler).Results.Peek()}");
        }

        static void Main(string[] args)
        {
            ICalc calc = new Calculator();

            calc.GotResult += Calculator_GotResult3;

            Execute(calc.Sum, double.MaxValue);
            Execute(calc.Sum, double.MaxValue);
            Console.WriteLine("--------------------");
            Execute(calc.Substract, double.MaxValue);
            Execute(calc.Substract, double.MaxValue);
            Execute(calc.Substract, double.MaxValue);
            Console.WriteLine("--------------------");
            Execute(calc.Divide, 0);
            Console.WriteLine("--------------------");
            Execute(calc.Multiply, 2);

        }
    }
}
