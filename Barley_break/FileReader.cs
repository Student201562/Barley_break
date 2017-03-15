using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Barley_break
{
    static class FileReader
    {
        public static int[] ReadFromFile(string file)
        {
            string FileSeparator = File.ReadAllText(file, Encoding.GetEncoding(1251));
            string[] mas = FileSeparator.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var getIntegerMassive = new int[mas.Length];
            for (int i = 0; i < getIntegerMassive.Length; i++)
            {
                try
                {
                    getIntegerMassive[i] = Convert.ToInt32(mas[i]);
                }
                catch (Exception)
                {
                    
                    throw new Exception("Некорректные данные");
                }
            }

            return getIntegerMassive;
        }
    }
}
