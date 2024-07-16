namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ////Вариант калькулятора для последовательного вычислений выражений вида '11 + 28 * 7 / 11 + ...'";
            double num1 = double.Parse(args[0]);
            char sign = char.Parse(args[1]);
            double num2 = double.Parse(args[2]);
            double res = 0;

            double SimpleCalc(double num1, char sign, double num2)
            {
                switch (sign)
                {
                    case '+':
                        res = num1 + num2;
                        break;
                    case '-':
                        res = num1 - num2;
                        break;
                    case '*':
                        res = num1 * num2;
                        break;
                    case '/':
                        res = num1 / num2;
                        break;
                }
                return res;
            }

            void PrintRes(string[] args, double res)
            {
                foreach (string item in args)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine($"= {res}");
            }


            res = SimpleCalc(num1, sign, num2);

            if (sign == '/' || sign == '*' || sign == '+' || sign == '-')
            {
                if (sign == '/' && num2 == 0)
                {
                    Console.WriteLine("Деление на ноль невозможно. Замените все делители на отличные от ноля");

                }
                else
                {
                    for (int i = 3; i < args.Length - 1; i += 2)
                    {
                        char signTemp = char.Parse(args[i]);
                        double num2Temp = double.Parse(args[i + 1]);
                        if (signTemp == '/' || signTemp == '*' || signTemp == '+' || signTemp == '-')
                        {
                            if (signTemp == '/' && num2Temp == 0)
                            {
                                Console.WriteLine("Деление на ноль невозможно. Замените все делители на отличные от ноля");
                                return;
                            }
                            else
                            {
                                res = SimpleCalc(res, signTemp, num2Temp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введен неизвестный оператор");
                            return;

                        }
                    }
                    PrintRes(args, res);
                }
            }
            else
            {
                Console.WriteLine("Введен неизвестный оператор");
            }




            ////Вариант калькулятора для выражений вида 'число 1' 'оператор + - / *' 'число 2'";
            //double num1 = double.Parse(args[0]);
            //char sign = char.Parse(args[1]);
            //double num2 = double.Parse(args[2]);
            //double res = 0;

            //switch (sign) 
            //{
            //    case '+':
            //        res = num1 + num2;
            //        break;
            //    case '-':
            //        res = num1 - num2;
            //        break;
            //    case '*':
            //        res = num1 * num2;
            //        break;
            //    case '/':
            //        if (num2 != 0)
            //        {
            //            res = num1 / num2;
            //           // res = Math.Round(res, 5);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Деление на ноль невозможно. Введите второе число отличное от ноля.");
            //            return;                        
            //        }                    
            //        break;
            //    default:
            //        Console.WriteLine("Введен неизвестный оператор");
            //        break;
            //}


            //Console.WriteLine($"{num1} {sign} {num2} = {res}");


        }
    }
}
