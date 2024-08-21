/*Представим, у нас есть интерфейс IMatrix, который позволяет получать и устанавливать значения в матрице по определенным координатам, 
    и класс Matrix, реализующий этот интерфейс для работы с матрицей.*/

namespace Devices2
{
    public interface IMatrix<T>
    {
        T this[int row, int column] { get; set; }

        void PrintMatrix();
    }

    public class Matrix<T>: IMatrix<T>
    {
        private T[,] arr;
        public Matrix(int rows, int columns)
        {
            arr = new T[rows, columns];
        }
        public T this[int row, int column]
        {
            get => arr[row, column];
            set => arr[row, column] = value;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }





    /* int[,] Array { get; set; }
             int GetArrayValue(int valueX, int valueY);
     void SetArrayValue(int valueX, int valueY, int value);*/



    internal class Class3
    {

    }
}

