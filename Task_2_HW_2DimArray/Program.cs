// Дан двумерный массив. Отсортировать данные по возрастанию
namespace Task_2_HW_2DimArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };


            int[] Convert2DimTo1DimArray(int[,] arr)
            {
                int arrayX = arr.GetLength(0);
                int arrayY = arr.GetLength(1);

                var ArrOneDimmensional = new int[arrayX * arrayY];

                for (int i = 0; i < arrayX; i++)
                {
                    for (int j = 0; j < arrayY; j++)
                    {
                        ArrOneDimmensional[arrayY * i + j] = a[i, j];
                    }

                }
                return ArrOneDimmensional;
            }

            int[,] Convert1DimTo2DimArray(int[] oneDimArr, int rowLength)
            {
                int colLenght = oneDimArr.Length / rowLength;
                var twoDimArr = new int[colLenght, rowLength];

                for (int i = 0; i < colLenght; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        twoDimArr[i, j] = oneDimArr[rowLength * i + j];
                    }
                }
                return twoDimArr;
            }

            void PrintArray(int[,] arr)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }


            PrintArray(a);
            Console.WriteLine();

            int[] oneDimArr = Convert2DimTo1DimArray(a);
            Array.Sort(oneDimArr); 

            PrintArray(Convert1DimTo2DimArray(oneDimArr, a.GetLength(1)));








        }
    }
}
