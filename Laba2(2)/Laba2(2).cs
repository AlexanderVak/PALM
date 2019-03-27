using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_2_
{
    class Program
    {
        static void Input(ref int row, ref int col, ref int[,] array)
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
        static void Output(int row, int col, int[,] array)
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Random(ref int row, ref int col, ref int[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                }
            }
        }
        static void Transpose(ref int size, ref int[,] array)
        {
            
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    int temp = array[i, j];
                    array[i, j] = array[j, i];
                    array[j, i] = temp;
                }

            }
            Output(size, size, array);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть розмiр матрицi");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[size, size];
            Console.WriteLine("Оберiть метод вводу - вручну (напишiть 1), випадкова матриця (напишiть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine();
                Input(ref size, ref size, ref array);
            }
            if (answer == "2")
            {
                Random(ref size, ref size, ref array);
            }
            else if (answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
                
            }
            Console.WriteLine("Отримаємо матрицю : ");
            Output(size, size, array);
            Console.WriteLine("Транспонована матриця : ");
            Transpose(ref size, ref array);
            Console.ReadKey();
        }
    }
}
