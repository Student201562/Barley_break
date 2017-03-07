using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BubleSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random gen = new Random();
            int[] mas = new int[10];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = gen.Next(0, 100);
                Console.Write(mas[i] + "\t");
            }
            Console.WriteLine();
            mas = BubbleSort(mas);

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + "\t");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        private static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
}
