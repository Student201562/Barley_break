using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barley_break
{
    internal class Game
    {
        private int[] numbers;
        private readonly int[,] gameField;
        private int moveValueX, moveValueY;
        private int coordinateZeroX, coordinateZeroY;

        public Game(int valueForPlay)
        {
            this.gameField = new int[valueForPlay,valueForPlay];
            FullMassiveNumbers();
            Shift();
        }
        public Game(string file)
        {
            string FileSeparator = File.ReadAllText(file, Encoding.GetEncoding(1251));
            string[] mas = FileSeparator.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (CheckStringINMassive(mas) == true)
            {
                gameField = new int[(int)Math.Sqrt(mas.Length), (int)Math.Sqrt(mas.Length)];
                numbers = new int[mas.Length];
                MethodWhichForemedMassiv(mas);
                Shift();
            }
        }
        private void FullMassiveNumbers()
        {
            Random gen = new Random();
            numbers = new int[gameField.Length]; 
            int count = 0;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if ((gameField.Length - 1) == count)
                    {
                        gameField[i, j] = 0;
                        numbers[count] = 0;
                    }
                    else
                    {
                        gameField[i, j] = count + 1;
                        numbers[count] = count + 1;
                        count++;
                    }
                }
            }
            Print.PrintData(gameField);
            GenerationNumbersOnField(gen);
            Print.PrintStartGame();
            System.Threading.Thread.Sleep(3000);
            Print.PrintData(gameField);
        }
        public  void GenerationNumbersOnField(Random gen)
        {
            //int temp = gameField[gameField.GetLength(0) -1, gameField.GetLength(1) - 1];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1] = gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2] = temp;

            int index = 0;
            int helpIndex = 0;
            //========================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    index = gen.Next(0, numbers.Length);
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        while ((numbers[index] == numbers[k]) && (numbers[index] == Int32.MaxValue))
                        {
                            index = gen.Next(0, numbers.Length);
                        }
                    }
                    gameField[i, j] = numbers[index];
                    numbers[index] = Int32.MaxValue;
                }
            }
            Print.PrintData(gameField);
            //========================
        }
        private void GetLocation(int moveValue)
        {
            moveValueX = 0;
            moveValueY = 0;
            coordinateZeroX = 0;
            coordinateZeroY = 0;
            //=========================================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (moveValue == gameField[i, j])
                    {
                        moveValueX = i;
                        moveValueY = j;
                    }
                    if (gameField[i,j] == 0)
                    {
                        coordinateZeroX = i;
                        coordinateZeroY = j;
                    }
                }
            }
            //=========================================
        }
        private void Shift()
        {
            int moveValue;
            int temp = 0;

            Print.PrintData(gameField);
            do
            {
                try
                {
                    Print.PrintNumber();
                    moveValue = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    moveValue = Convert.ToInt32(Console.ReadLine());
                }
                GetLocation(moveValue);
            } while (CheckMoveValue(moveValue) != true);
            // Перемещение
            temp = gameField[moveValueX, moveValueY];
            gameField[moveValueX, moveValueY] = gameField[coordinateZeroX, coordinateZeroY];
            gameField[coordinateZeroX, coordinateZeroY] = temp;
            Console.Beep();
            
            if (CheckWin() == true)
            {
                Print.PrintWin();
            }
            else
            {
                Print.PrintData(gameField);
                Shift();
            }
        }
        private bool CheckMoveValue(int moveValue)
        {
            int count = 0;

            if (Math.Sqrt(Math.Pow(moveValueX - coordinateZeroX,2) + Math.Pow(moveValueY - coordinateZeroY, 2)) == 1)
            {
                count++;
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckWin()
        {
            Print.PrintData(gameField);
            int count = 0;
            //=======================================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    numbers[count] = gameField[i, j];
                    count++;
                }
            }

            count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[numbers.Length - 1] == 0)
                    {
                        if ((i == numbers.Length - 1) || (j == numbers.Length - 1))
                        {
                        }
                        else
                        {
                            if (j > i)
                            {
                                if (numbers[i] > numbers[j])
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            if (count < 1)
            {
                return true;
            }
            else
                return false;
            //==================================
        }
        private bool CheckStringINMassive(string[] masStr)
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
        private bool CheckIntegerInMassive(string[] masStr)
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
                if(CheckDemensionMassive(masStr) == true)
                { 
                    return true;
                }
                else
                {
                    Print.PrintError();
                    throw  new Exception("Ошибка!!!");
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
        private bool CheckDemensionMassive(string[] masStr)
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
        private void MethodWhichForemedMassiv(string[] masStr)
        {
            
            int helper = 0;
            for (int i = 0; i < Math.Sqrt(masStr.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(masStr.Length); j++)
                {
                    gameField[i, j] = Int32.Parse(masStr[helper]);
                    helper++;
                }
            }
        }

    }
}