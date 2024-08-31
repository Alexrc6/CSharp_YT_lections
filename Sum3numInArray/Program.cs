/*Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
    Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.*/

namespace Sum3numInArray
{
    internal class Program
    {
        static void NumOfSumFinder(int[] ints, int numSum)
        {
            Queue<int> q = new(ints);

            int num1;
            int num2;
            int num3;
            bool flag = false;

            while (q.Count > 0)
            {
                num1 = q.Dequeue();
                Queue<int> q2 = new(q);
                while (q2.Count > 0)
                {
                    num2 = q2.Dequeue();
                    num3 = numSum - num1 - num2;
                    if (q2.Any(num => num == (num3)))
                    {
                        Console.WriteLine($"{num1}, {num2}, {num3}");
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Ни одного сочетания равного {numSum} не найдено.");
            }
        }

        static void Main(string[] args)
        {
            int[] mas = { 80, 61, 87, 53, 36, 178, 66, 74, 39, 82, 84, 311, 59, 92, 21, 84, 72, 91, 36, -43, 94, 96, 7, 86, 40 };
            int number = 108;

            NumOfSumFinder(mas, number);
        }
    }
}
