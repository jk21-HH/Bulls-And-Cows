using System;

namespace Bulls_And_Cows
{
    public class Board
    {
        private const string k_StrHeadLine = "|Pins:    |Result:|";
        private const string k_HideRandLine = "| # # # # |       |";
        private const string k_StrSeparateLine = "|=========|=======|";
        private const int k_TableWidth = 8;

        private readonly int r_NumOfGuess;
        private readonly char[,] r_GameBoard;
        private int m_GuessCounter = 0;

        public Board(int i_NumOfGuess)
        {
            this.r_NumOfGuess = i_NumOfGuess;
            this.r_GameBoard = new char[i_NumOfGuess, k_TableWidth];
            for (int i = 0; i < i_NumOfGuess; i++)
            {
                for (int j = 0; j < k_TableWidth; j++)
                {
                    r_GameBoard[i, j] = ' ';
                }
            }
        }

        public void PrintBoard(string i_CompStr, int i_NumOfGuess)
        {
            if (i_NumOfGuess > m_GuessCounter)
            {
                Console.WriteLine("{0}", k_StrHeadLine);
                Console.WriteLine("{0}", k_StrSeparateLine);
                Console.WriteLine("{0}", k_HideRandLine);
                Console.WriteLine("{0}", k_StrSeparateLine);
            }
            else
            {
                Console.WriteLine("{0}", k_StrHeadLine);
                Console.WriteLine("{0}", k_StrSeparateLine);
                Console.WriteLine(
                    "| {0} {1} {2} {3} |       |",
                    i_CompStr[0],
                    i_CompStr[1],
                    i_CompStr[2],
                    i_CompStr[3]);
                Console.WriteLine("{0}", k_StrSeparateLine);
            }

            for (int i = 0; i < r_NumOfGuess; i++)
            {
                printLine(i);
            }

            m_GuessCounter++;
        }

        private void printLine(int i_NumOfLines)
        {
            Console.WriteLine(
                "| {0} {1} {2} {3} |{4} {5} {6} {7}|",
            r_GameBoard[i_NumOfLines, 0],
            r_GameBoard[i_NumOfLines, 1],
            r_GameBoard[i_NumOfLines, 2],
            r_GameBoard[i_NumOfLines, 3],
            r_GameBoard[i_NumOfLines, 4],
            r_GameBoard[i_NumOfLines, 5],
            r_GameBoard[i_NumOfLines, 6],
            r_GameBoard[i_NumOfLines, 7]);
            Console.WriteLine("{0}", k_StrSeparateLine);
        }

        public void UpdateBoard(string i_UserGuess, string i_GuessResult, int i_NumOfGuess)
        {
            for (int i = 0; i < k_TableWidth / 2; i++)
            {
                r_GameBoard[i_NumOfGuess, i] = i_UserGuess[i];
            }

            for (int j = k_TableWidth / 2, i = 0; j < k_TableWidth; j++, i++)
            {
                r_GameBoard[i_NumOfGuess, j] = i_GuessResult[i];
            }
        }
    }
}