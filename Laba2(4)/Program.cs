using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_4_
{
    class Program
    {
        static void Input(ref int size, ref int[][] array)
        {
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                array[i] = input.Split(' ').Select(int.Parse).ToArray();
            }
        }
        static void Output(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Random(ref int[][] array)
        {
            Random rnd = new Random();
            Console.WriteLine("Отримаємо матрицю : ");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(-5, 5);
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void DeleteRows(ref int[][] array, int k1, int k2, int size)
        {
            
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = k1 - 1; j <= k2 - 1; j++)
                {
                    if (i == j)
                    {
                        array[i] = array[count];
                        count++;
                    }
                }
            }
            Array.Reverse(array);
            Array.Resize(ref array, size - count);
            Array.Reverse(array);
            Output(array);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть номер першого рядка для видалення ");
            int k1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть номер другого рядка для видалення ");
            int k2 = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[size][];
            for (int i = 0; i < size; i++)
            {
                array[i] = new int[size];
            }
            Console.WriteLine("Оберiть метод вводу - вручну (напишiть 1), випадкова матриця (напишiть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Input(ref size, ref array);
                Console.WriteLine("Отримаємо матрицю : ");
                Console.WriteLine();
                Output(array);
            }
            if (answer == "2")
            {
                Random(ref array);
            }
            else if (answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
            }
            Console.WriteLine("Масив пiсля видалення рядкiв");
            DeleteRows(ref array, k1, k2, size);
            Console.ReadKey();
        }
    }
}
