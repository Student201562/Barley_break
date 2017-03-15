using System;
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
        public readonly int[,] gameField;
        // Конструктор, который работает с цифрами
        public Game(params int[] valueForPlay)
        {
            if (IsExsistGameField(valueForPlay))
            {
                int size = (int) Math.Sqrt(valueForPlay.Length);
                int temp = 0;

                this.gameField = new int[size, size];
                for (int i = 0; i < gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        gameField[i, j] = valueForPlay[temp];
                        temp++;
                    }
                }
                GenerationNumbersOnField();
            }
            else
            {
                throw new Exception();
            }

        }
        //Заполнение вспомогательного массива Numbers
        public static bool IsExsistGameField(int[] valueForPlay)
        {
            int count = 0;

            if (Math.Sqrt(valueForPlay.Length) % 1 == 0)
            {
                count = 1;
            }
            //=====================
            int zeroCount = 0;
            for (int i = 0; i < valueForPlay.Length; i++)
            {
                if (valueForPlay[i] == 0)
                {
                    zeroCount ++;
                }
            }

            for (int i = 0; i < valueForPlay.Length; i++)
            {
                for (int j = 0; j < valueForPlay.Length; j++)
                {
                    if (i < j)
                    {
                        if (valueForPlay[i] == valueForPlay[j])
                        {
                            return false;
                        }
                    }
                }
            }

            if ((count == 1) && (zeroCount == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int this[int i, int j]
        {
            get { return gameField[i, j]; }
        }

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
            //========================
        }
        // Метод, который находит координаты
        private int[] GetLocation(int moveValue)
        {
            int[] pointsXandY = new int[2];

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == moveValue)
                    {
                        pointsXandY[0] = i;
                        pointsXandY[1] = j;
                    }
                }
            }
            return pointsXandY;
        }
        // Метод, который отвечает за перемещение
        public bool Shift(int moveValue)
        {
            int count = 0;
            int temp = 0;
            int moveValueX = 0, moveValueY = 0, coordinateZeroX = 0, coordinateZeroY = 0;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i,j] == moveValue)
                    {
                        moveValueX = i;
                        moveValueY = j;
                        count++;
                    }
                    if (gameField[i,j] == 0)
                    {
                        coordinateZeroX = i;
                        coordinateZeroY = j;
                        count++;
                    }
                }
            }

            if ((count == 2) && (Math.Sqrt(Math.Pow(moveValueX - coordinateZeroX, 2) + Math.Pow(moveValueY - coordinateZeroY, 2)) == 1))
            {
                // Перемещение
                temp = gameField[moveValueX, moveValueY];
                gameField[moveValueX, moveValueY] = gameField[coordinateZeroX, coordinateZeroY];
                gameField[coordinateZeroX, coordinateZeroY] = temp;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Метод, который проверяет выйграл ли пользователь
        public bool CheckWin()
        {
            int[] numbers = new int[gameField.Length];
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
    }
}
