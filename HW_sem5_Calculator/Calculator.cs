namespace HW_sem5_Calculator
{
    internal class Calculator : ICalc
    {
        public Stack<double> resStack = new Stack<double>();

        public Calculator()
        {
            resStack.Push(0);
        }

        public event EventHandler<EventArgs> GotResult;

        public void RiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void Add(double value)
        {
            resStack.Push(resStack.Peek() + value);
            RiseEvent();
        }
        public void Divide(double value)
        {
            resStack.Push(resStack.Peek() / value);
            RiseEvent();
        }
        public void Multiply(double value)
        {
            resStack.Push(resStack.Peek() * value);
            RiseEvent();
        }
        public void Substract(double value)
        {
            resStack.Push(resStack.Peek() - value);
            RiseEvent();
        }
        public void ClearLast()
        {
            if (resStack.Count > 0)
                resStack.Pop();
            Console.WriteLine("Последнее действие отменено.");
            RiseEvent();
        }

        public void AddFirsrNum()
        {
            string str;
            double input1;

            while (true)
            {
                Console.WriteLine("введите первое число");
                str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("пример чисел для ввода 5 или -46");
                }
                else if (double.TryParse(str, out input1))
                {
                    resStack.Push(input1);
                    break;
                }
                else
                {
                    Console.WriteLine("Испльзуйте правильный формат");
                }

            }

            RiseEvent();
        }
    }
}
