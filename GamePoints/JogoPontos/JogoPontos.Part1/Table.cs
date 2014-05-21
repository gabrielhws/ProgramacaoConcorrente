using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JogoPontos.Part1
{
    public class Table
    {
        private const int MAX = 4;
        private const string SPACE = " ";
        private const string BLANK = "";
        private const string PONTO = " . ";
        private const string UNDERLINE = "_";
        private const string PIPE = "| ";
        private const string PIPE_UNDERLINE = "|_";

        string[,] _buffer = new string[MAX, MAX];

        
        static void Main(string[] args)
        {
            Table t = new Table();
            t.Initialize();
            t.Print();

            for(int i = 0; i < MAX; i++)
                 t.Game();

            t.Print();

            Console.ReadKey();

        }

        private void Initialize()
        {
            for (int row = 0; row < MAX; row++)
            {

                for (int col = 0; col < MAX; col++)
                {
                    _buffer[row, col] = PONTO;

                }
            }

        }

        private void Print()
        {
            Console.WriteLine();
            for (int row = 0; row < MAX; row++)
            {
                Console.Write("\t\t");
                for (int col = 0; col < MAX; col++)
                {
                    Console.Write(_buffer[row, col]);

                }
                Console.WriteLine();
            }

        }

        void Game()
        {
            int rowCurrent;
            int colCurrent;

            do
            {
                rowCurrent = RowFirst();
                colCurrent = ColFirst();
            } while (!_buffer[rowCurrent, colCurrent].Equals(PONTO));

            int row;
            int col;

            do
            {
                row = RowSecond(rowCurrent);
                col = ColSecond(row, rowCurrent, colCurrent);
            } while (!_buffer[row, col].Equals(PONTO));

            if (rowCurrent == row)
            {
                if (_buffer[rowCurrent, colCurrent].Equals(PIPE))
                    _buffer[rowCurrent, colCurrent] = PIPE_UNDERLINE;
                else
                {
                    _buffer[rowCurrent, colCurrent] = UNDERLINE;
                    _buffer[row, col] = SPACE;
                }
            }

            if(colCurrent == col)
            {
                if (_buffer[rowCurrent, colCurrent].Equals(UNDERLINE))
                {
                    _buffer[rowCurrent, colCurrent] = PIPE_UNDERLINE;
                    _buffer[row, col] = BLANK;
                } else
                    _buffer[rowCurrent, colCurrent] = PIPE;
            }
     
        }

        int RowFirst()
        {
            return NumberRandom(0, MAX);
        }

        int ColFirst()
        {
            return NumberRandom(0, MAX);
        }

        int RowSecond(int rowCurrent)
        {
            if (rowCurrent == 0)
                return NumberRandom(0, rowCurrent + 1);
            else
                return NumberRandom(rowCurrent - 1, rowCurrent + 1);
        }

        int ColSecond(int row, int rowCurrent, int colCurrent)
        {
            if (row == rowCurrent)
            {
                int col;
                do
                {
                    col = NumberRandom(0, MAX);
                } while (colCurrent == col);
                return col;
            }

            return NumberRandom(0, MAX);
        }


        private int NumberRandom(int min, int max)
        {
            return new Random().Next(min, max);
        }



    }
}
