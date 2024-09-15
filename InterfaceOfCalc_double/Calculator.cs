namespace InterfaceOfCalc
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        void Sum(int value);
        void Substract(int value);
        void Multiply(int value);
        void Divide(int value);
        void CancelLast();

        void Sum(double value);
        void Substract(double value);
        void Multiply(double value);
        void Divide(double value);
    }
}
