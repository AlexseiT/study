// See https://aka.ms/new-console-template for more information

namespace Example
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Тесты");
            Console.WriteLine();

            RomanNumber Obj1 = new RomanNumber(12);
            RomanNumber Obj2 = new RomanNumber(230);
            RomanNumber Obj3 = new RomanNumber(1560);

            Console.WriteLine("12 : XII : " + Obj1.ToString());
            Console.WriteLine("230 : CCXXX : " + Obj2.ToString());
            Console.WriteLine("1560 : MDLX : " + Obj3.ToString());

            Console.WriteLine();

            Console.WriteLine("12 + 230 = 242 : CCXLII : " + RomanNumber.Add(Obj1, Obj2).ToString());
            Console.WriteLine("1560 - 230 = 1330 : MCCCXXX : " + RomanNumber.Sub(Obj3, Obj2).ToString());
            Console.WriteLine("12 * 230 = 2760 : MMDCCLX : " + RomanNumber.Mul(Obj1, Obj2).ToString());
            Console.WriteLine("1560 / 12 = 130 : CXXX : " + RomanNumber.Div(Obj3, Obj1).ToString());

            Console.WriteLine();

            Console.WriteLine("Массив:");
            RomanNumber[] mass = { Obj2, Obj3, Obj1};
            for (int i = 0; i < mass.Length; i++) Console.WriteLine(mass[i]);

            Console.WriteLine();

            Console.WriteLine("Отсортированный Массив:");

            Array.Sort(mass);

            for (int i = 0; i < mass.Length; i++) Console.WriteLine(mass[i]);

            Console.WriteLine();

            Console.WriteLine("Копирование элемента 230 : CCXLII ");

            var Obj4 = (RomanNumber)Obj2.Clone();

            Console.WriteLine(Obj4.ToString());

        }
    }
}