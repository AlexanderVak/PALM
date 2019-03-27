
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_3_
{
    class Program
    {
        static void OutputWithoutOdds(ref int size, ref int[] array)
        {
           int count = 0;
           for(int i = 0; i < size; i++)
           {
                if (array[i] % 2 == 0)
                {
                    int temp = array[i];
                    array[i] = array[0 + count];
                    array[0 + count] = temp;
                    count++;
                }

           }
            Array.Reverse(array);
            Array.Resize(ref array, size - count);
            Array.Reverse(array);
           for (int i = 0; i < array.Length; i++)
           {
              Console.Write("{0} ", array[i]);
           }
        }
        static void Output(int size, int[] array)
        {
           for (int i = 0; i < size; i++)
           {
              Console.Write("{0} ", array[i]);
           }
        }
        static void Random(ref int size, ref int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть розмiр маcиву");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Оберiть метод вводу - вручну (напишiть 1), випадкова матриця (напишiть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
               Console.WriteLine();
               string input = Console.ReadLine();
               array = input.Split(' ').Select(int.Parse).ToArray() ;
            }
            if (answer == "2")
            {
                Random(ref size, ref array);
            }
            else if (answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
                
            }
            Console.WriteLine("Отримаємо масив : ");
            Console.WriteLine();
            Output(size, array);
            Console.WriteLine("\nМасив без парних : ");
            Console.WriteLine();
            OutputWithoutOdds(ref size, ref array);
            Console.ReadKey();
        }
    }
}
