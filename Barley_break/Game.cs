using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    internal class Game
    {
        private int[] numbers;
        private int[,] gameField;
        private int moveValueX, moveValueY;


        public Game(params int[] valueForPlay)
        {
            this.numbers = valueForPlay;
            CheckValue();
            CalculationSizeOfPlayField();
        }

        private void CheckValue()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    if ((numbers[i] == numbers[j]) && (i != j))
                    {
                        throw new Exception("Некорректные данные");
                    }
                }
            }
        }

        private void CalculationSizeOfPlayField()
        {
            int size = (int) Math.Sqrt(numbers.Length);
            int count = 0;
            //========================================
            if (size == Math.Sqrt(numbers.Length))
            {
                gameField = new int[size, size];

                for (int i = 0; i < gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        gameField[i, j] = numbers[count];
                        count++;
                    }
                }
            }
            else
            {
                throw new Exception("Некорректные данные");
            }
            //========================================
        }

        public void GenerationNumbersOnField(Random gen)
        {
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
            // Print();
            //========================
        }

        public void Print()
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    Console.Write(gameField[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void GetLocation(int moveValue)
        {
            moveValueX = 0;
            moveValueY = 0;
            //=========================================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (moveValue == gameField[i, j])
                    {
                        moveValueX = i;
                        moveValueY = j;
                        break;
                    }
                }
            }
            //=========================================
        }

        public void Shift(int valueWhichEnterUser)
        {
            int coordinateZeroX = 0;
            int coordinateZeroY = 0;
            int[,] temp = new int[1, 1];

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    // нахождение координат нуля
                    if (gameField[i, j] == 0)
                    {
                        coordinateZeroX = i;
                        coordinateZeroY = j;
                        break;
                    }
                }
            }
            // перемещение
            if (Math.Abs(moveValueX - coordinateZeroX) == 1 && moveValueY == coordinateZeroY)
            {
                temp[0, 0] = gameField[moveValueX, moveValueY];
                gameField[moveValueX, moveValueY] = gameField[coordinateZeroX, coordinateZeroY];
                gameField[coordinateZeroX, coordinateZeroY] = temp[0, 0];
            }
            if (Math.Abs(moveValueY - coordinateZeroY) == 1 && moveValueX == coordinateZeroX)
            {
                temp[0, 0] = gameField[moveValueX, moveValueY];
                gameField[moveValueX, moveValueY] = gameField[coordinateZeroX, coordinateZeroY];
                gameField[coordinateZeroX, coordinateZeroY] = temp[0, 0];
            }
            //
        }

        //public bool CheckWin()
        //{
        //    int count = 0;
        //    //=======================================
        //    for (int i = 0; i < gameField.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < gameField.GetLength(1); j++)
        //        {
        //            numbers[count] = gameField[i,j];
        //            count++;
        //        }
        //    }

        //    count = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        for (int j = 0; j < numbers.Length - 1; j++)
        //        {
        //            if (numbers[j+1] < numbers[j])
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                if (j == numbers[numbers.Length-1])
        //                {
                            
        //                }
        //            }
        //        }
        //    }
        //    if (count == 1)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
            //=======================================
        }
    }
}