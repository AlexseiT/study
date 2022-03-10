using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RomanNumberExtend : RomanNumber
{
    private static readonly Dictionary<char, int> pair =
        new Dictionary<char, int> {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

    public RomanNumberExtend(string num)  : base(1) {
        int number = 0;
        int pred_number = 0;
        int count = 0;
        bool check = true;
        foreach (char ch in num)
        {
            if (check == true)
            {
                int curr = pair[ch];
                if (number == curr) count++; else count = 0;

                if (count >= 1 && ( curr == 5 || curr == 50 || curr == 500 )) check = false;
                if (count >= 3 && (curr != 5 || curr != 50 || curr != 500)) check = false;

                if (curr > number) pred_number += curr - 2 * number;
                else pred_number += curr;
                number = curr;
            }
            else throw new RomanNumberException("Неверная запись числа");
        }
        ch = Convert.ToUInt16(number);
    }
}

