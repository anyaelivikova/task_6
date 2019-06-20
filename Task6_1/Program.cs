using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_14
{
    class Program
    {
        static void PrintArray(double[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        static void FillArray(double[] a, int k)
        {
            if (k >= a.Length)
                return;

            a[k] = (a[k - 1] + a[k - 2]) / 2 - a[k - 3];

            FillArray(a, k + 1);
        }

        static int LenghtUpSubset(double[] a)
        {
            int maxLenght = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                int len = 1;

                while ((i + 1) < a.Length && a[i + 1] > a[i])
                {
                    i++;
                    len++;
                }

                if (len > maxLenght)
                    maxLenght = len;
            }

            return maxLenght;
        }

        static void ShowMaxUpSubset(double[] a, int maxLenght)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int len = 1;
                int start = i;

                while ((i + 1) < a.Length && a[i + 1] > a[i])
                {
                    i++;
                    len++;
                }

                int end = i + 1;

                if (len == maxLenght)
                {
                    Console.WriteLine("Возрастающая последовательность:");
                    for (int j = start; j < end; j++)
                    {
                        Console.Write(a[j] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Последний элемент возрастающей последовательности: " + a[end - 1]);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("<<< задача 6 >>>");
            Console.WriteLine();

            int n = 0;
            double a1 = 0, a2 = 0, a3 = 0;

            Console.Write(" Введите количество элементов последовательности, равное N = ");
            check(ref n);

            Console.Write("Введите a1 = ");
            cheking(ref a1);

            Console.Write("Введите a2 = ");
            cheking(ref a2);

            Console.Write("Введите a3 = ");
            cheking(ref a3);

            double[] a = new double[n];
            a[0] = a1;
            a[1] = a2;
            a[2] = a3;

            FillArray(a, 3);
            PrintArray(a);

            int maxLen = LenghtUpSubset(a);

            Console.WriteLine();
            Console.WriteLine($"Максимальная длина возрастающей последовательности = {maxLen}");

            ShowMaxUpSubset(a, maxLen);

            Console.ReadLine();
        }
        static double cheking(ref double n)
        {
            bool ok = false;
            while (!ok)
            {
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out n);
                if (!ok)
                {
                    Console.WriteLine("Вводите только вещественные числа! Повторите ввод");
                    ok = false;
                }
                else ok = true;
            }
            return n;
        }

        static int check(ref int k)
        {
            bool ok = false;
            while (!ok)
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out k) && (k >= 3);
                if (!ok && k == 0)
                {
                    Console.WriteLine("Последовательность пуста! Повторите ввод");
                    ok = false;
                }
                else
                {
                    if (!ok && k <= 3) { Console.WriteLine("Невозможно создать последовательность меньше чем из трех элементов! Повторите ввод"); ok = false; }
                    else
                    {
                        if (!ok)
                        {
                            Console.WriteLine("Вводите только натуральные числа! Повторите ввод");
                            ok = false;
                        }
                        else ok = true;
                    }
                }
            }
            return k;
        }
    }
}
