using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_sem5_Calculator
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        void Add(double value);
        void Substract (double value);
        void Multiply (double value);
        void Divide (double value);
        void ClearLast();
        void AddFirsrNum();
    }
}
