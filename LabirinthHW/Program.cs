//ДЗ - вернуть все выходы

namespace Labirinth2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
               {1, 1, 1, 1, 1, 1, 1 },
               {1, 1, 0, 0, 0, 0, 1 },
               {1, 1, 1, 1, 1, 0, 1 },
               {2, 0, 0, 0, 1, 0, 2 },
               {1, 1, 0, 2, 1, 1, 1 },
               {1, 1, 1, 1, 1, 1, 1 },
               {1, 1, 1, 2, 1, 1, 1 }
            };

            var _path = new Stack<(int, int)>();
            var _exits = new Queue<(int, int)>();

            PathFinder(3, 2);

            void PathFinder(int x, int y)
            {
                if (labirynth1[x, y] == 2)
                {
                    Console.WriteLine("Заданная точка является точкой выхода");
                    return;
                }

                if (labirynth1[x, y] == 1)
                {
                    Console.WriteLine("Точка входа задана неверно");
                    return;
                }

                if (labirynth1[x, y] == 0)
                    _path.Push(new(x, y));

                while (_path.Count > 0)
                {
                    var current = _path.Pop();

                    //Console.WriteLine(current);

                    if (current.Item2 + 1 < labirynth1.GetLength(dimension: 1) && labirynth1[current.Item1, current.Item2 + 1] == 2)
                    {
                        _exits.Enqueue(new(current.Item1, current.Item2 + 1));
                        labirynth1[current.Item1, current.Item2 + 1] = 1;
                    }

                    if (current.Item1 + 1 < labirynth1.GetLength(dimension: 0) && labirynth1[current.Item1 + 1, current.Item2] == 2)
                    {
                        _exits.Enqueue(new(current.Item1 + 1, current.Item2));
                        labirynth1[current.Item1 + 1, current.Item2] = 1;
                    }

                    if (current.Item2 - 1 > -1 && labirynth1[current.Item1, current.Item2 - 1] == 2)
                    {
                        _exits.Enqueue(new(current.Item1, current.Item2 - 1));
                        labirynth1[current.Item1, current.Item2 - 1] = 1;
                    }

                    if (current.Item1 - 1 > -1 && labirynth1[current.Item1 - 1, current.Item2] == 2)
                    {
                        _exits.Enqueue(new(current.Item1 - 1, current.Item2));
                        labirynth1[current.Item1 - 1, current.Item2] = 1;
                    }


                    if (current.Item2 + 1 < labirynth1.GetLength(dimension: 1) && labirynth1[current.Item1, current.Item2 + 1] == 0)
                        _path.Push(new(current.Item1, current.Item2 + 1));
                    if (current.Item1 + 1 < labirynth1.GetLength(dimension: 0) && labirynth1[current.Item1 + 1, current.Item2] == 0)
                        _path.Push(new(current.Item1 + 1, current.Item2));
                    if (current.Item2 - 1 > -1 && labirynth1[current.Item1, current.Item2 - 1] == 0)
                        _path.Push(new(current.Item1, current.Item2 - 1));
                    if (current.Item1 - 1 > -1 && labirynth1[current.Item1 - 1, current.Item2] == 0)
                        _path.Push(new(current.Item1 - 1, current.Item2));

                    labirynth1[current.Item1, current.Item2] = 1;
                }

                if (_exits.Count == 0)
                    Console.WriteLine("Выхода нет.");

                while (_exits.Count > 0)
                {
                    Console.WriteLine($"Координаты выхода: {_exits.Dequeue()}");
                }

                return;
            }
        }
    }
}
