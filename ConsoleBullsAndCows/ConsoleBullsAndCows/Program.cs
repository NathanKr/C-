using System;

/*
 *  NOTICE : 
 *  class Program is implemented below beside getting MAX_GUESS_NUMBER\WORD_LENGTH from the user
 *  you need to implement class BullsCowsGame so the game can be functional
 * 
 */



namespace ConsoleBullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bPlayAgain;
            bcGame = new BullsCowsGame(MAX_GUESS_NUMBER, WORD_LENGTH);

            do
            {
                PrintIntro();
                PlayGame();
                bPlayAgain = AskToPlayAgain();
            } while (bPlayAgain);

        }



        static readonly int MAX_GUESS_NUMBER = 15;// --- todo get this from the user !!!!!!!
        static readonly int WORD_LENGTH = 4; // --- todo get this from the user !!!!!!!
        static BullsCowsGame bcGame;

        static void PrintIntro()
        {
            Console.WriteLine("                     (__)      (__)");  
            Console.WriteLine("                     (oo)      (oo)");
            Console.WriteLine("               /------\\/        \\/ --------\\");
            Console.WriteLine("              / |     ||        ||_______|  \\");
            Console.WriteLine("             *  ||W---||        ||      ||   *");
            Console.WriteLine("                ^^    ^^        ^^      ^^");

            Console.WriteLine("Welcome to Bulls and Cows , a fun word game");
            Console.WriteLine("can you guess the  { 0}  letters word i think about ?", WORD_LENGTH);
            Console.WriteLine("you have  { 0}  tries", MAX_GUESS_NUMBER);
        }

        

        static void PrintNonValidGuessError(GuessStatus status)
        {
            string strErr = "";

            switch (status)
            {
                case GuessStatus.Ok:
                    // -- nothing to print
                    break;

                case GuessStatus.Wrong_Number_Of_Letters:
                    strErr = "Wrong number of characters";
                    break;

                case GuessStatus.Only_Lowercase_Letters_Allowed:
                    strErr = "Not all Character\\s are lower case letters";
                    break;

                case GuessStatus.Letter_Is_Not_Unique:
                    strErr = "Letter\\s are not unique";
                    break;

                default:
                    strErr = "Unexpected error";
                    break;
            }

            if (strErr.Length > 0)
            {
                Console.WriteLine("Error : {0}\n\n", strErr);  
            }
        }

        static void PlayGame()
        {
            string strGuess;
            GuessStatus status;
            bcGame.Reset();
            BullsCowsCount count;

            while ((bcGame.GetCurrentTry() < bcGame.GetMaxTries()) && !bcGame.IsGameWon())
            {
                do
                {
                    strGuess = GetGuess();
                    status = bcGame.CheckGuessValid(strGuess);
                    PrintNonValidGuessError(status);
                } while (status != GuessStatus.Ok);


                count = bcGame.SubmitValidGuess(strGuess);

                Console.WriteLine("Try : {0} of {1}",bcGame.GetCurrentTry()  , bcGame.GetMaxTries());
                Console.WriteLine("Bulls : {0}" , count.GetBulls());
                Console.WriteLine("Cows : {0}\n", count.GetCows());
            }

            Console.WriteLine(bcGame.IsGameWon() ? "YOU WIN" : "YOU LOSE") ;
            Console.Write("\n\n");
        }

        static bool AskToPlayAgain()
        {
            string answer;
            Console.WriteLine("Do you want to play again [y/n] ? "); 
            answer = Console.ReadLine();

            return (answer[0] == 'y');
        }

        static string GetGuess()
        {
            string guess;
            Console.WriteLine("enter your guess : ");
            guess = Console.ReadLine();

            return guess;
        }
    }
}
