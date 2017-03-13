﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barley_break
{
    public class Game
    {
        private int[,] gameField;
        private int moveValueX, moveValueY;
        private int coordinateZeroX, coordinateZeroY;
        // Конструктор, который работает с цифрами
        public Game(int valueForPlay)
        {
            this.gameField = new int[valueForPlay, valueForPlay];
            FullMassive();
            Shift();
        }
        // Конструктор, который работает с файлом
        public Game(string file)
        {
            string[] mas = FileReader.ReadForFile(file);
            if (FileReader.CheckStringINMassive(mas) == true)
            {
                gameField = new int[(int)Math.Sqrt(mas.Length), (int)Math.Sqrt(mas.Length)];
                MethodWhichForemedMassiv(mas);
                Shift();
            }
        }
        // Заполнение вспомогательного массива Numbers
        private void FullMassive()
        {
            int count = 1;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if ((i == gameField.GetLength(0) - 1) && (j == gameField.GetLength(1) - 1))
                    {
                        gameField[i, j] = 0;
                    }
                    else
                    {
                        gameField[i, j] = count;
                        count++;
                    }
                }
            }
            Print.PrintGameField(gameField);
            System.Threading.Thread.Sleep(2000);
            GenerationNumbersOnField();
            Print.PrintStartGame();
            Print.PrintGameField(gameField);
        }
        public int this[int i, int j]
        {
            get { return gameField[i, j]; }
        }
        // Генерация игрового поля
        public void GenerationNumbersOnField()
        {
            Random gen = new Random();
            int temp = 0;
            //int temp = gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1] = gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2] = temp;

            int index = 0;
            //========================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    int x = gen.Next(0, gameField.GetLength(0));
                    int y = gen.Next(0, gameField.GetLength(1));
                    temp = gameField[x, y];
                    gameField[x, y] = gameField[i, j];
                    gameField[i, j] = temp;
                }
            }
            Print.PrintGameField(gameField);
            //========================
        }
        // Метод, который находит координаты
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
                    if (gameField[i, j] == 0)
                    {
                        coordinateZeroX = i;
                        coordinateZeroY = j;
                    }
                }
            }
            //=========================================
        }
        // Метод, который отвечает за перемещение
        private void Shift()
        {
            int moveValue;
            int temp = 0;

            Print.PrintGameField(gameField);
            do
            {
                try
                {
                    Print.PrintEnterNumber();
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
                Print.PrintGameField(gameField);
                Shift();
            }
        }
        // Метод, который проверяет на возможность перемещения
        private bool CheckMoveValue(int moveValue)
        {
            int count = 0;

            if (Math.Sqrt(Math.Pow(moveValueX - coordinateZeroX, 2) + Math.Pow(moveValueY - coordinateZeroY, 2)) == 1)
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
        // Метод, который проверяет выйграл ли пользователь
        private bool CheckWin()
        {
            int[] numbers = new int[gameField.Length];
            Print.PrintGameField(gameField);
            int count = 0;
            //=======================================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for(int j = 0; j < gameField.GetLength(1); j++)
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
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
            //==================================
        }
        // Метод, который заполняет массив
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
