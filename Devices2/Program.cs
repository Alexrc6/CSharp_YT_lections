/*Спроектируйте интерфейс для класса способного устанавливать и получать значения отдельных бит в заданном числе.
 * 
 * реализовать интерфейс из прошлой задачи применив его к классу bits из примера предыдущей лекции.
 * 
 * Предположим, у вас есть некоторый набор устройств, 
    каждое из которых может быть включено или выключено, 
    и вы хотите иметь возможность выполнять операции над этими устройствами через битовые операторы.*/

/*Представим, у нас есть интерфейс IMatrix, который позволяет получать и устанавливать значения в матрице по определенным координатам, 
    и класс Matrix, реализующий этот интерфейс для работы с матрицей.*/




namespace Devices2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bits bits = new(63);
            // Console.WriteLine(bits.GetBitByIndex(2));
            // bits.SetBitByIndex(0, true);
            // Console.WriteLine(bits.GetBitByIndex(0));

            // bits[1] = true;
            // Console.WriteLine(bits[1]);
            // Console.WriteLine(bits.Value);
            /* Console.WriteLine((byte)bits);
             Console.WriteLine(bits);
             byte val = bits;
             Console.WriteLine(val);*/

            /*Devices devices = new();
            Bits bits2 = new(63);
            Console.WriteLine(devices);
            devices.TurnOnOff(bits2);
            Console.WriteLine(devices);*/


            Devices devices2 = new();
            int num = 2;
            Bits bits3 = new((Bits)num);
            devices2.TurnOnOff(bits3);
            Console.WriteLine(devices2);
            
            Devices devices3 = new();
            long num2 = 5;
            Bits bits4 = new((Bits)num2);
            devices3.TurnOnOff(bits4);
            Console.WriteLine(devices3);

            Devices devices4 = new();
            int num3 = 7;
            devices4.TurnOnOff(num3);
            Console.WriteLine(devices4);

            Devices devices5 = new();
            long num4 = 11;
            devices5.TurnOnOff(num4);
            Console.WriteLine(devices5);

           /* Matrix<int> array = new Matrix<int>(2, 2);

            array[0, 0] = 1;
            array[0, 1] = 2;
            array[1, 0] = 3;
            array[1, 1] = 4;

            array.PrintMatrix();*/


        }
    }
}
