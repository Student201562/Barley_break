using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    public class Print
    {
        // Вывод игрового поля
        public static void PrintGameField(int[,] gameField)
        {
            Console.Clear();
            Console.CursorTop = 3;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameField[i, j] + "\t");
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(gameField[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
        // Вывод, что вы выйграли
        public static void PrintWin()
        {
            Console.WriteLine("\t\t\tВы выйграли!!!");
        }
        public static void PrintNumberWhichEnterUser()
        {
            Console.Write("Введите размерность поля = ");
        }
        // Информация для пользователя
        public static void PrintEnterNumber()
        {
            Console.Write("\t\tВведите число которое хотите поменять = ");
        }
        public static void PrintStartGame()
        {
            Console.Write("\t\tПодождите пока поле перемешается");
        }
        public static void PrintError()
        {
            Console.WriteLine("\t\t\tОшибка!!!");
        }
    }
}