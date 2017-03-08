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
        private readonly int[,] gameField;
        private int moveValueX, moveValueY;


        public Game(int valueForPlay)
        {
            this.gameField = new int[valueForPlay,valueForPlay];
            FullMassiveNumbers();
        }
        private void FullMassiveNumbers()
        {
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
        }
        public  void GenerationNumbersOnField(Random gen)
        {
            //int temp = gameField[3, 3];
            //gameField[3, 3] = gameField[3, 2];
            //gameField[3, 2] = temp;

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
            //Print.PrintData(gameField);
            //========================
        }
        public  void GetLocation(int moveValue)
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
        public  void Shift(int valueWhichEnterUser)
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
                        Print.PrintData(gameField);
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
                Console.Beep();
            }
            if (Math.Abs(moveValueY - coordinateZeroY) == 1 && moveValueX == coordinateZeroX)
            {
                temp[0, 0] = gameField[moveValueX, moveValueY];
                gameField[moveValueX, moveValueY] = gameField[coordinateZeroX, coordinateZeroY];
                gameField[coordinateZeroX, coordinateZeroY] = temp[0, 0];
                Console.Beep();
            }
            //
        }

        public  bool CheckWin()
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
            }
            if (count < 1)
            {
                Console.WriteLine("Вы выйграли!!!");
                return true;
            }
            else
                return false;
            //==================================
        }
    }
}
// нужен когда game() передают игровое поле
//private void CheckValue()
//{
//    for (int i = 0; i < numbers.Length; i++)
//    {
//        for (int j = numbers.Length - 1; j > 0; j--)
//        {
//            if ((numbers[i] == numbers[j]) && (i != j))
//            {
//                throw new Exception("Некорректные данные");
//            }
//        }
//    }
//}
//private void CalculationSizeOfPlayField()
//{

//    int size = gameField.GetLength(0);
//    int count = 0;
//    //========================================
//    if ( size > 0 )
//    {
//       // gameField = new int[size, size];

//        for (int i = 0; i < gameField.GetLength(0); i++)
//        {
//            for (int j = 0; j < gameField.GetLength(1); j++)
//            {
//                gameField[i, j] = numbers[count];
//                if (gameField[i, j] >= 0)
//                {

//                }
//                else
//                {
//                    throw new Exception("Есть отрицательные значения, поменяйте их");
//                }
//                gameField[i, j] = numbers[count];
//                count++;
//            }
//        }
//    }
//    else
//    {
//        throw new Exception("Некорректные данные");
//    }
//    Print.PrintData(gameField);
//    //========================================
//}