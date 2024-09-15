

namespace InterfaceOfCalc
{
    internal class Calculator : ICalc
    {
        public Stack<double> Results = new();
        private Stack<CalcActionLog> actions = new();
        public double result = 0;
        public Calculator()
        {
            Results.Push(0);
        }

        public event EventHandler<EventArgs> GotResult;
        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void Divide(int value)
        {
            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("Нельзя делить на 0", actions);
            }

            try
            {
                checked
                {
                    result = Results.Peek() / value;
                    Results.Push(result);
                    RaiseEvent();
                }
            }
            catch (OverflowException)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculateOperationCauseOverflowException("Результат превышает диапазон int", actions);
            }
        }

        public void Multiply(int value)
        {
            long temp = (long)(value * Results.Peek());

            if (temp > int.MaxValue || temp < int.MinValue)
            {
                actions.Push(new CalcActionLog(CalcAction.Multiple, value));
                throw new CalculateOperationCauseOverflowException("Результат превышает диапазон int", actions);
            }

            result = (int)temp;
            Results.Push(result);
            RaiseEvent();
        }

        public void Substract(int value)
        {
            long temp = (long)Results.Peek() - value;

            if (temp > int.MaxValue || temp < int.MinValue)
            {
                actions.Push(new CalcActionLog(CalcAction.Substract, value));
                throw new CalculateOperationCauseOverflowException("Результат превышает диапазон int", actions);
            }

            result = (int)temp;
            Results.Push(result);
            RaiseEvent();
        }

        public void Sum(int value)
        {

            long temp = (long)(value + Results.Peek());

            if (temp > int.MaxValue || temp < int.MinValue)
            {
                actions.Push(new CalcActionLog(CalcAction.Add, value));
                throw new CalculateOperationCauseOverflowException("Результат превышает диапазон int", actions);
            }

            result = (int)temp;
            Results.Push(result);
            RaiseEvent();
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
                Results.Pop();
            RaiseEvent();
        }

        public void Sum(double value)
        {
          
            double currentResult = Results.Peek();

            if ((value > 0 && currentResult > double.MaxValue - value) ||
                (value < 0 && currentResult < -double.MaxValue - value))
            {
                actions.Push(new CalcActionLog(CalcAction.Add, value));
                throw new CalculateOperationCauseOverflowException($"Переполнение при сложении {currentResult} и {value}.", actions);
            }

            result = currentResult + value;

            if (double.IsInfinity(result))
            {
                actions.Push(new CalcActionLog(CalcAction.Add, value));
                throw new CalculateOperationCauseOverflowException(
                    $"Результат сложения {currentResult} и {value} привёл к бесконечности.", actions);
            }

            Results.Push(result);
            actions.Push(new CalcActionLog(CalcAction.Add, value));
            RaiseEvent();

        }

        public void Substract(double value)
        {
            double currentResult = Results.Peek();

            if ((value > 0 && currentResult < -double.MaxValue + value) ||
                (value < 0 && currentResult > double.MaxValue + value))
            {
                actions.Push(new CalcActionLog(CalcAction.Substract, value));
                throw new CalculateOperationCauseOverflowException($"Переполнение при вычитании {value} из {currentResult}.", actions);
            }
            else
            {
               result = currentResult - value;
            }

            Results.Push(result);
            actions.Push(new CalcActionLog(CalcAction.Substract, value));
            RaiseEvent();
        }

        public void Multiply(double value)
        {
            double currentResult = Results.Peek();

            if ((currentResult > 0 && value > 0 && currentResult > double.MaxValue / value) ||
                (currentResult < 0 && value < 0 && currentResult < double.MaxValue / value) ||
                (currentResult > 0 && value < 0 && currentResult > -double.MaxValue / value) ||
                (currentResult < 0 && value > 0 && currentResult < -double.MaxValue / value))
            {
                actions.Push(new CalcActionLog(CalcAction.Multiple, value));
                throw new CalculateOperationCauseOverflowException($"Переполнение при умножении {currentResult} на {value}.", actions);
            }
            else
            {
                result = currentResult * value;
            }

            Results.Push(result);
            actions.Push(new CalcActionLog(CalcAction.Multiple, value));
            RaiseEvent();
        }

        public void Divide(double value)
        {
            double currentResult = Results.Peek();

            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("Нельзя делить на 0", actions);
            }

            if ((currentResult == double.MaxValue && value < 1 && value > 0) ||
                (currentResult == -double.MaxValue && value > -1 && value < 0))
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculateOperationCauseOverflowException($"Переполнение при делении {currentResult} на {value}.", actions);
            }
            else
            {
               result = currentResult / value;
            }

            Results.Push(result);
            actions.Push(new CalcActionLog(CalcAction.Divide, value));
            RaiseEvent();
        }
    }
}
