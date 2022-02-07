using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    class Program
    {
        public string PrintExcelColumnName(int n)
        {
            var result = string.Empty;
            while (n >= 1)
            {
                var lastChar = n % 26;
                result = (char)('A' + lastChar - 1) + result;
                n = n / 26;
            }

            return result;
        }

        public bool IsUnique(string inputString)
        {
            var charArray = inputString.ToCharArray();
            var countArray = new int[255];
            for (int i = 0; i < charArray.Length; i++)
            {
                if (countArray[charArray[i]] >= 1)
                {
                    return false;
                }

                countArray[charArray[i]]++;
            }

            return true;
        }
        public int MyAtoi(string s)
        {
            var charArray = s.ToCharArray();
            var length = charArray.Length;
            var strippedString = string.Empty;
            var isNegative = false;
            var numberList = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < length; i++)
            {
                if (charArray[i].Equals('-'))
                {
                    isNegative = true;
                }

                if (numberList.Contains(charArray[i]))
                {
                    strippedString += charArray[i].ToString();
                }
            }

            var strippedLength = strippedString.Length;
            var strippedArray = strippedString.ToCharArray();
            long number1 = 0;
            int number = 0;
            for (int i = 0; i < strippedLength; i++)
            {
                number1 = number1 * 10 + Convert.ToInt32(strippedArray[i].ToString());
            }

            if (number1 < (0 - Math.Pow(2, -31)))
            {
                return (int)(0 - Math.Pow(2, -31));
            }

            if (number1 > Math.Pow(2, 31) - 1)
            {
                return (int)(Math.Pow(2, 31) - 1);
            }

            if (isNegative)
            {
                number1 = 0 - number1;
            }

            return (int)number1;
        }

        public bool BackspaceCompare(string s, string t)
        {
            var length = s.Length;
            var a1 = s.ToCharArray();
            var a2 = t.ToCharArray();
            var s1 = string.Empty;
            var s2 = string.Empty;
            int i = length - 2;
            if (a1[length-1] != '#')
            {
                s1 = a1[length - 1].ToString();
            }
            if (a2[length - 1] != '#')
            {
                s2 = a2[length - 1].ToString();
            }
            while (i >= 0)
            {
                if (a1[i] != '#' && a1[i+1] != '#')
                {
                    s1 += a1[i];
                    i--;
                }

                i = i - 2;
            }

            i = length - 2;
            while (i >= 0)
            {
                if (a2[i] != '#' && a2[i+1] != '#')
                {
                    s2 += a2[i];
                    i--;
                }

                i = i - 2;
            }

            return s1.Equals(s2);
        }
        static void Main(string[] args)
        {
            var p = new Program();
            var sudokuHelper = new SudokuSolver();
            var input = new char[][] { 
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' }, 
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' }, 
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, 
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' }, 
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, 
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' }, 
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, 
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' }, 
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }};

            var sudoku = sudokuHelper.GetSolvedSudoku(input);

            while (Array.Exists(sudoku, x => x.Contains('.')))
            {
                sudokuHelper.GetSolvedSudoku(sudoku);
            }

            for (int i = 0; i < sudoku.Length; i++)
            {
                for (int j = 0; j < sudoku.Length; j++)
                {
                    Console.Write(sudoku[i][j].ToString() + " ");
                }

                Console.WriteLine();
            }

            //p.BackspaceCompare("ab##", "c#d#");
            //Console.WriteLine(p.PrintExcelColumnName(123));

            Console.ReadLine();
        }
    }
}
