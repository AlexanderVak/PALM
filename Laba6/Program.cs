using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Laba6
{
    class Program
    {
        static Invoice[] MyInput()
        {
            Invoice[] _array = new Invoice[0];
            bool flag = true;
            Console.WriteLine("Enter \"End\" to finish the formation of data");

            int i = 0;
            while (flag == true)
            {
                string inputString = Console.ReadLine();

                if (inputString == "End")
                  flag = false;
                else
                {
                    Invoice _string = new Invoice(inputString);
                    Array.Resize(ref _array, _array.Length + 1);
                    _array[i] = _string;
                    i++;
                }
            }
            return _array;
        }

        static void Saving(Invoice[] _array)
        {
            using (StreamWriter streamWriter = new StreamWriter("invoice.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    streamWriter.WriteLine($"{_array[i].numberOfInvoice} {_array[i].date} {_array[i].counterparty} {_array[i].numberOfContract} {_array[i].sum}");
                }
            }

                XmlSerializer serializer = new XmlSerializer(typeof(Invoice[]));
            using (FileStream fileStream = new FileStream("invoice.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, _array);
            }
        }

        static void Launch_Menu()
        {
            Console.WriteLine("If you want to create new file enter \"1\". Enter \"2\" to work with already existing files");
            string answer = Console.ReadLine();
            switch(answer)
            {
                case "1":
                    Console.WriteLine("Enter all data:");
                    Invoice[] _array = MyInput();
                    Array.Sort(_array);
                    Saving(_array);
                    ReadFile_Menu();
                    break;
                case "2":
                    ReadFile_Menu();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.ReadKey();
                    break;
            }
        }

        static void RunProgram(Invoice[] _array)
        {
            Console.WriteLine("Enter number of contract you are looking for");
            int findContract = Convert.ToInt32(Console.ReadLine());

            bool exists = false;

            Console.WriteLine("Invoice information");
            for (int i = 0; i < _array.Length; i++)
            {
                if (findContract == (_array[i].numberOfContract))
                {
                    int uah = _array[i].sum / 100;
                    string formattedSum = $"{uah}uah {_array[i].sum - uah * 100}cop";
                    string output = $"Such invoice exists\n№ {_array[i].numberOfInvoice} date {_array[i].date} name of counterparty \"{_array[i].counterparty}\" sum {formattedSum}";
                    Console.WriteLine(output);
                    exists = true;
                }
            }
            if (exists == false)
            {
                Console.WriteLine("This invoice does not exist");
            }
        }

        static void ReadFile_Menu()
        {
            Console.WriteLine("Enter\"1\" to read from txt file or \"2\" to read from xml fileZ");
            string answer = Console.ReadLine();
            switch(answer)
            {
                case "1":
                    using (StreamReader streamReader = new StreamReader("invoice.txt", System.Text.Encoding.Default))
                    {
                        Invoice[] _array = new Invoice[0];
                        int i = 0;
                        string _string;

                        while((_string = streamReader.ReadLine()) != null)
                        {
                            Invoice _newString = new Invoice(_string);
                            Array.Resize(ref _array, _array.Length + 1);
                            _array[i] = _newString;
                            i++;
                        }
                        RunProgram(_array);
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    XmlSerializer serializer = new XmlSerializer(typeof(Invoice[]));
                    using (FileStream fileStream = new FileStream("invoice.xml", FileMode.OpenOrCreate))
                    {
                        Invoice[] new_array = (Invoice[])serializer.Deserialize(fileStream);
                        RunProgram(new_array);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.ReadKey();
                    break;
            }

        }
        static void Main(string[] args)
        {
            Launch_Menu();
        }
    }
}
