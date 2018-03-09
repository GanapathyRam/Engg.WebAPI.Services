using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic
{
    public class Constant
    {

        public static readonly string[] Columns = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC","AD", "AE"};

        public static readonly string YearByAlphabet = "Q";

        public static readonly int StartYear = 2017;


        public static string GetMonthByAlphabet(int index)
        {
            if (index <= 0)
                throw new IndexOutOfRangeException("index must be a positive number");

            return Columns[index - 1];
        }

        public static string GetYearByAlphabet(int year)
        {

            Debug.Assert(YearByAlphabet.Length == 1 && Regex.IsMatch(YearByAlphabet, "[a-yA-y]"));

            int CurrentYear = year - StartYear;
            var next = (char)(YearByAlphabet[0] + CurrentYear);

            int IndexByYear = Array.FindIndex(Columns, m => m == YearByAlphabet);

            return Columns[IndexByYear];

        }
    }
}
