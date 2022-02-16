using System;
public class HW1
{
    public static void PrintMass(int[][] A, int n)
    {
        Console.WriteLine("--------------");
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < A[i].Length; j++)
            {
                Console.Write($" {A[i][j]}");
            }
            Console.WriteLine("");
        }
    }
    public static long QueueTime(int[] customers, int n)
    {
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            if (i == 0) array[i] = new int[customers.Length];
            else array[i] = new int[1];
        }

        for (int i = 0; i < customers.Length; i++)
        {
            array[0][i] = customers[i];
        }

        int check = 0;
        int timer= 0;
        while (check != n)
        {
            timer++;

            //PrintMass(array,n);

            check = 0;
            for (int i = 0; i < n; i++)
            {
            if (array[i][0] == 0)
                {
                    int s = 1;
                    while (array[0][s] == 0)
                    {
                        s++;
                        if (s == customers.Length) break;
                    }
                    if (s != customers.Length)
                    {
                        array[i][0] = array[0][s];
                        array[0][s] = 0;
                    }
                }
            if (array[i][0] != 0) array[i][0]--;
            }
            for (int i = 0; i < n; i++)
            {
                if (array[i][0] == 0) check++;
            }
            if (check == n) 
            for (int i = 0; i < customers.Length; i++) if (array[0][i] != 0) check = 0;
            
        }
        return timer;
    }
}
namespace Example
{
    class Program
    {
        static void Main()
        {

            int[] Test1 = { 5, 3, 4 };
            Console.WriteLine($"Тест 1 Время = {HW1.QueueTime(Test1, 1)}");
            int[] Test2 = { 10, 2, 3, 3 };
            Console.WriteLine($"Тест 2 Время = {HW1.QueueTime(Test2, 2)}");
            int[] Test3 = { 2, 3, 10};
            Console.WriteLine($"Тест 3 Время = {HW1.QueueTime(Test3, 2)}");
            Console.WriteLine("Ввод с клавиатуры ");
            Console.Write("Количество людей ");

            int kol = int.Parse(Console.ReadLine());

            int[] customers = new int[kol];

            for (int i = 0; i < customers.Length; i++)

            {

                Console.Write($"Время для {i + 1} покупателя: ");

                customers[i] = int.Parse(Console.ReadLine());

            }

            Console.Write("Количество касс: ");

            int n = int.Parse(Console.ReadLine());

            Console.Write($"Время = {HW1.QueueTime(customers, n)}");
        }
    }
}