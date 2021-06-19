using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obliczenia_równoległe_mnożenie_macierzy_02_12_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] result = new int[6, 5];
            int[,] a = { { 4, 2, 8, 11, 55 }, { 5, 12, 23, 44, 1 },{12,53,53,55,453 },{ 12,543,54,55,11},{ 13,143,44,44,5} };
            int[,] b = { { 3, 2 }, { 3, 3 }, { 51, 26 }, { 7, 11 }, { 9, 10 } };

            Parallel.For(0, a.GetUpperBound(1), (int z) =>
            {
              
                    for (int y = 0; y < a.GetUpperBound(z) / 2; y++)
                    {
                        for (int h = 0; h <= b.GetUpperBound(1); h++)
                        {
                            for (int g = 0; g <= a.GetUpperBound(1); g++)
                            {
                                lock (result)
                                {
                                    result[y, h] += a[y, g] * b[g, h];
                                }
                                }
                        }
                    }
               
                //if (z == 1)
                //{
                //    for (int y = a.GetUpperBound(0) / 2; y <= a.GetUpperBound(0); y++)
                //    {
                //        for (int h = 0; h <= b.GetUpperBound(1); h++)
                //        {
                //            for (int g = 0; g <= a.GetUpperBound(1); g++)
                //            {
                //                result[y, h] += a[y, g] * b[g, h];
                //            }
                //        }
                //    }
                //}

            });
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{result[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
