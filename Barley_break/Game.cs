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
        private int[,] gameField;
        public readonly int sizeField;
        // Конструктор, который работает с цифрами
        public Game(params int[] valueForPlay)
        {
            if (IsExsistGameField(valueForPlay))
            {
                sizeField = (int) Math.Sqrt(valueForPlay.Length);
                int temp = 0;

                this.gameField = new int[sizeField, sizeField];
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
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == moveValue)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return null;
        }
        // Метод, который отвечает за перемещение
        public bool Shift(int moveValue)
        {
            int count = 0;
            int temp = 0;
            int[] massiveZero;
            int[] massiveMoveValue;

            massiveZero = GetLocation(0);
            massiveMoveValue = GetLocation(moveValue);

            if ((massiveMoveValue != null) && (Math.Sqrt(Math.Pow(massiveMoveValue[0] - massiveZero[0], 2) + Math.Pow(massiveMoveValue[1] - massiveZero[1], 2)) == 1))
            {
                // Перемещение
                temp = gameField[massiveMoveValue[0], massiveMoveValue[1]];
                gameField[massiveMoveValue[0], massiveMoveValue[1]] = gameField[massiveZero[0], massiveZero[1]];
                gameField[massiveZero[0], massiveZero[1]] = temp;
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
    }
}
