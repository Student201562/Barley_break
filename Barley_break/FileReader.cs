using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class FileReader
    {
        public static bool CheckStringINMassive(string[] masStr)
        {
            string[] letters = new[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
                "V", "W", "X", "Y", "Z",
                "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У",
                "Ф", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я",
                "!","@","$","%","^","&","*","(",")","-","_","+","=","{","}","[","]","/",@"\","|","?","№"
            };

            int count = 0;
            for (int i = 0; i < masStr.Length; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    if (masStr[i].Contains(letters[j]) == true)
                    {
                        count++;
                    }

                    if (masStr[i].Contains(letters[j].ToLower()) == true)
                    {
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                Print.PrintError();
                throw new Exception("Ошибка!!!");
                return false;
            }
            else
            {
                if (CheckIntegerInMassive(masStr) == true)
                {
                    return true;
                }
                else
                {
                    Print.PrintError();
                    throw new Exception("Ошибка!!!");
                    return false;
                }
            }
        }
        // Метод, который проверяет на весь ли массив заполнен цифрами
        public static bool CheckIntegerInMassive(string[] masStr)
        {
            int count = 0;
            for (int i = 0; i < masStr.Length; i++)
            {
                for (int j = 0; j < masStr.Length; j++)
                {
                    if (Int32.Parse(masStr[j]) == i)
                    {
                        count++;
                        break;
                    }
                }
            }
            if ((count == masStr.Length))
            {
                if (CheckDemensionMassive(masStr) == true)
                {
                    return true;
                }
                else
                {
                    Print.PrintError();
                    throw new Exception("Ошибка!!!");
                    return false;
                }
            }
            else
            {
                Print.PrintError();
                throw new Exception("Ошибка!!!");
                return false;
            }
        }
        // Метод, который проверяет адекватность размерности 
        public static bool CheckDemensionMassive(string[] masStr)
        {
            int size = (int)Math.Sqrt(masStr.Length);
            int count = 0;

            if (Math.Sqrt(masStr.Length) == size)
            {
                count++;
            }
            //=====================
            if (count > 0)
            {
                return true;
            }
            else
            {
                Print.PrintError();
                throw new Exception("Ошибка!!!");
                return false;
            }
        }
    }
}
