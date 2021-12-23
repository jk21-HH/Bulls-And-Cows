using System;
using System.Linq;
using System.Text;
using Ex02.ConsoleUtils;

namespace Bulls_And_Cows
{
    public class Game
    {
        private const string k_CorrectGuess = "X";
        private const string k_CorrectGuessAndPlace = "V";
        private const int k_RandStrLength = 4;
        private const string k_LettersToRandFrom = "ABCDEFGH";

        private readonly int r_NumOfGuess;
        private readonly Board r_GameBoard;

        public Game(int i_NumOfGuesses)
        {
            r_NumOfGuess = i_NumOfGuesses;
            r_GameBoard = new Board(r_NumOfGuess);
        }

        public void PlayGame(out bool io_GameOn)
        {
            string compStr = randString();
            bool flagForWin = false;
            int stepsToWin = 0;
            for (int i = 0; i < r_NumOfGuess; i++)
            {
                Screen.Clear();
                r_GameBoard.PrintBoard(compStr, r_NumOfGuess);
                string currentUserGuess = UserInterface.GetUserInput();
                if (UserInterface.IsQuitter(currentUserGuess))
                {
                    Console.WriteLine("You pressed Q. See you later!");
                    io_GameOn = false;
                    return;
                }

                string guessRes = checkGuessIsBull(currentUserGuess, compStr);
                r_GameBoard.UpdateBoard(currentUserGuess, guessRes, i);
                stepsToWin++;
                if (checkIsWinner(guessRes))
                {
                    flagForWin = true;
                    break;
                }
            }

            Screen.Clear();
            r_GameBoard.PrintBoard(compStr, r_NumOfGuess);
            if (flagForWin)
            {
                UserInterface.IsWinner(stepsToWin);
            }
            else
            {
                UserInterface.IsLoser();
            }

            io_GameOn = true;
        }

        private static string randString()
        {
            var randObj = new Random();
            string strRand = new string(
                k_LettersToRandFrom.OrderBy(i_RandNext => randObj.Next()).Take(k_RandStrLength).ToArray());
            return strRand;
        }

        private static string checkGuessIsBull(string i_InputUser, string i_RandString)
        {
            int countV = 0, countX = 0;
            if (Equals(i_RandString, i_InputUser))
            {
                countV = 4;
            }
            else
            {
                for (int i = 0; i < i_InputUser.Length; i++)
                {
                    for (int j = 0; j < i_RandString.Length; j++)
                    {
                        if (i_InputUser[i] == i_RandString[j] && i == j)
                        {
                            countV++;
                        }
                        else
                        {
                            if (i_InputUser[i] == i_RandString[j])
                            {
                                countX++;
                            }
                        }
                    }
                }
            }

            string fillGuessResult = updateGuessResultStr(countV, countX);
            return fillGuessResult;
        }

        private static string updateGuessResultStr(int i_CountV, int i_CountX)
        {
            StringBuilder fillGuessResult = new StringBuilder();
            for (int i = 0; i < i_CountV; i++)
            {
                fillGuessResult.Append(k_CorrectGuessAndPlace);
            }

            for (int i = 0; i < i_CountX; i++)
            {
                fillGuessResult.Append(k_CorrectGuess);
            }

            while (fillGuessResult.Length < 4)
            {
                fillGuessResult.Append(' ');
            }

            string strFillBullsAndCows = fillGuessResult.ToString();
            return strFillBullsAndCows;
        }

        private static bool checkIsWinner(string i_GuessResult)
        {
            bool isWin = true;
            foreach (char t in i_GuessResult)
            {
                if (t != 'V')
                {
                    isWin = false;
                    break;
                }
            }

            return isWin;
        }
    }
}