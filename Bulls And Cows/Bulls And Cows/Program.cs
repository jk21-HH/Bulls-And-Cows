using System;
using System.Threading;

namespace Bulls_And_Cows
{
    public class Program
    {
        public static void Main()
        {
            bool isPlay = true;
            while (isPlay)
            {
                Console.Clear();
                Game currentGame = new Game(UserInterface.GetNumberOfGuesses());
                currentGame.PlayGame(out isPlay);
                if (!isPlay)
                {
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    isPlay = UserInterface.IsNewGame();
                }
            }
        }
    }
}