using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_1_
{
    class Program
    {
        static void Input(int row, int col, int[,] array)
        {

            for (int i = 0; i < row; i++)
            {
                int[] rows = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = rows[j];
                }
            }
        }
        static void Random(int row, int col, int[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                }
            }
        }
        static void Output(int row, int col, int[,] array)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Multiplication(int row, int col, int[,] array)
        {

            for (int i = 0; i < col; i++)
            {
                long result = 1;
                bool flag = true;
                for (int j = 0; j < row; j++)
                {
                    if (array[j, i] == 0)
                    {
                        flag = false;
                        break;
                    }
                    result *= array[j, i];
                }
                if (flag)
                    Console.WriteLine("В стовпчику {0} добуток = {1}", i + 1, result);

            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введшть кiлькiсть рядкiв в матрицi");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпчикiв в матрицi");
            int columms = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[rows, columms];
            Console.WriteLine("Оберiть метод вводу - вручну (напишiть 1), випадкова матриця (напишiть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine();
                Input(rows, columms, array);
            }
            if (answer == "2")
            {
                Random(rows, columms, array);
            }
            else if (answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
            }
            Console.WriteLine("Отримаємо матрицю : ");
            Output(rows, columms, array);
            Console.WriteLine();
            Multiplication(rows, columms, array);
            Console.ReadKey();
        }
    }
}
