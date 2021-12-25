using System;

namespace Bulls_And_Cows
{
    public class UserInterface
    {
        private const int k_MinNumGuesses = 4;
        private const int k_MaxNumGuesses = 10;
        private const string k_Yes = "Y";
        private const string k_No = "N";
        private const string k_Quit = "Q";

        public static int GetNumberOfGuesses()
        {
            Console.WriteLine("Please enter a number of guesses you would like - 4/5/6/7/8/9/10 Guesses  ");
            bool isValid = false;
            int intNumOfGuesses = 0;
            do
            {
                string strNumOfGuess = Console.ReadLine();
                isValid = int.TryParse(strNumOfGuess, out intNumOfGuesses);
                if (!isValid)
                {
                    Console.WriteLine("Wrong input. Type numbers only.");
                    Console.WriteLine("Please enter a number of guesses you would like - 4/5/6/7/8/9/10 Guesses  ");
                }
                else
                {
                    if ((intNumOfGuesses > k_MaxNumGuesses) || (intNumOfGuesses < k_MinNumGuesses))
                    {
                        Console.WriteLine("Wrong input. Out of range.");
                        Console.WriteLine("Please enter a number of guesses you would like - 4/5/6/7/8/9/10 Guesses  ");
                    }
                }
            }
            while ((intNumOfGuesses > k_MaxNumGuesses || intNumOfGuesses < k_MinNumGuesses) || (!isValid));

            return intNumOfGuesses;
        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            string userGuess = Console.ReadLine();
            while (!IsQuitter(userGuess) && (!isInLetterRange(userGuess) || !isInLengthRange(userGuess)
                                                                        || !areInputLettersSame(userGuess)))
            {
                Console.WriteLine(
                    "Invalid input, follow the orders. Please type your next guess <A B C D> or 'Q' to quit");
                userGuess = Console.ReadLine();
            }

            return userGuess;
        }

        private static bool isInLetterRange(string i_InputUser)
        {
            bool isValid = true;
            foreach (char t in i_InputUser)
            {
                if (t < 'A' || t > 'H')
                {
                    Console.WriteLine("Letters are out of range. Letters from A - H");
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool isInLengthRange(string i_InputUser)
        {
            return i_InputUser.Length == 4;
        }

        private static bool areInputLettersSame(string i_InputUser)
        {
            bool isValid = true;
            char[] chArray = i_InputUser.ToCharArray();
            Array.Sort(chArray);
            for (int i = 0; i < chArray.Length - 1; i++)
            {
                if (chArray[i] != chArray[i + 1])
                {
                    continue;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public static void IsWinner(int i_GuessNumber)
        {
            Console.WriteLine("You guessed after {0} steps!", i_GuessNumber);
        }

        public static void IsLoser()
        {
            Console.WriteLine("No more guesses allowed. You Lost.");
        }

        public static bool IsQuitter(string i_UserInput)
        {
            return i_UserInput == k_Quit;
        }

        public static bool IsNewGame()
        {
            Console.WriteLine("Would you like to start a new game? <Y/N>");
            string userDecision = Console.ReadLine();
            userDecision = userDecision.ToUpper();
            while (userDecision != k_Yes && userDecision != k_No)
            {
                Console.WriteLine("Invalid input. Would you like to start a new game? <Y/N>");
                userDecision = Console.ReadLine();
                userDecision = userDecision.ToUpper();
            }

            return userDecision == k_Yes;
        }
    }
}