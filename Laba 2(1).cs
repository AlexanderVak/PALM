using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Program
    {
        static void Input (int row, int col, int[,] array)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        static void Random (int row, int col, int[,] array)
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
        static int Multiplication(int row, int col, int[,] array)
        {
            int result = 1;
            for (int i = 0; i < col; i++)
            {
                bool flag = true;
                for (int j = 0; j < row; j++)
                {
                    if (array[j, i] == 0)
                    {
                        flag = false;
                        break;
                    }
                    else result *= array[i, j]; 
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть кількість рядків в матриці");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпчиків в матриці");
            int columms = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[rows, columms];
            Console.WriteLine("Оберіть метод вводу - вручну (напишіть 1), випадкова матриця (напишіть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Input(rows, columms, array);
            }
            if (answer == "2")
            {
                Random(rows, columms, array);
            }
            else if ( answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
            }
            Console.WriteLine("Отримаэмо матрицю : ");
            Output(rows, columms, array);
            Console.WriteLine("добуток елементів у кожному стовпці, що не містить нуля дорівнює "+ Multiplication(rows, columms, array));
            Console.ReadKey();
        }
    }
}
