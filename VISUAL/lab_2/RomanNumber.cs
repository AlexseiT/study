
public class RomanNumber : ICloneable, IComparable
{
    private ushort ch;
    //Конструктор получает число n, которое должен представлять объект класса
    public RomanNumber(ushort n)
    {
        if (n > 0 || n < 4000) ch = n;
        else throw new RomanNumberException("Входные данные меньше или равны 0");
    }
    //Сложение римских чисел
    public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.ch + n2.ch > 3999) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.ch + n2.ch));
    }
    //Вычитание римских чисел
    public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.ch - n2.ch <= 0) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.ch - n2.ch));
    }
    //Умножение римских чисел
    public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.ch * n2.ch > 3999 || n1.ch * n2.ch <= 0) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.ch * n2.ch));
    }
    //Целочисленное деление римских чисел
    public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n2.ch == 0 || n1.ch / n2.ch <= 0) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.ch / n2.ch));
    }
    //Возвращает строковое представление римского числа
    public override string ToString()
    {
        string ch_string = "";

        char[] Alfavit = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

        ushort ch_element = ch;

        int counter = 0;

        while (ch_element != 0)
        {
            counter++;
            ch_element /= 10;
        }


        ch_element = ch;
        double element = 0;
        double element_des = 0;

        for (int i = counter - 1; i >= 0; i--)
        {

            double ch_count = Math.Floor(ch_element / Math.Pow(10, i));

            element = ch_count - element_des;

            element_des = ch_count * 10;

            if (element > 0 && element <= 3)
            {
                for (int j = 0; j < element; j++) ch_string += Alfavit[6 - 2 * i];
            }

            if (element == 4)
            {
                ch_string += Alfavit[6 - 2 * i];
                ch_string += Alfavit[5 - 2 * i];
            }

            if (element >= 5 && element <= 8)
            {
                ch_string += Alfavit[5 - 2 * i];
                for (int j = 0; j < element - 5; j++) ch_string += Alfavit[6 - 2 * i];
            }

            if (element == 9)
            {
                ch_string += Alfavit[6 - 2 * i];
                ch_string += Alfavit[6 - 2 * (i + 1)];
            }
        }
        return ch_string;
    }
    //Реализация интерфейса IClonable
    public object Clone()
    {
        return new RomanNumber(ch);
    }
    //Реализация интерфейса IComparable
    public int CompareTo(object? obj)
    {
        if (obj is RomanNumber number)
        {
            return number.ch - ch;
        }
        else throw new ArgumentException("Неверрные параметры");
    }
}
