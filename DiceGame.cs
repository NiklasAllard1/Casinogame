
public class DiceGamE
    {
        public static void PlayDiceGame(ref int balance)
        {
            int choice = 0;
            StartCasino(choice, ref balance);
        }
    static void StartCasino(int choice, ref int balance) // Metod
    {
        while (true)
        {
            Clear();
            WriteLine("Welcome to 7 is heaven.\nSelect option \n1 - Start playing\n2 - Information about the game\n3 - Exit");

            if (!int.TryParse(ReadLine(), out choice))
            {
                WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            if (choice == 3)
            {
                WriteLine("Leaving table.");
                break;
            }
            
            else if (choice == 2)
            {
                GameInfo();

                WriteLine("Press Enter to continue");
                ReadLine();
            }
            else if (choice == 1)
            {
                DiceGame(ref balance);
            }
        }
    }

    static void GameInfo()//metod
    {
        string rowSeparator = new string('-', count: 74);
        WriteLine("Information about the game \nThe game will let you throw a 100-sided dice");  //Display menu for bonuses            
        WriteLine(rowSeparator);
        WriteLine("All bonuses");
        WriteLine("All bet sizes");
        WriteLine("1. Low (1-40) \n2. Middle (41-70)  \n3. High (71-100)");
        WriteLine("If you roll a 7, your bet will be x100 and other bets will be x3");
    }

   static void DiceGame(ref int balance)//metod
    {
    
    WriteLine($"Your current balance is: {balance}");

        while (balance > 0)
        {
            WriteLine("Choose a betting range:");
            WriteLine("1. Low (1-40) \n2. Middle (41-70) \n3. High (71-100) \n4. Quit");

            int choice = 0;
            try
            {
                choice = int.Parse(ReadLine()); // fångar up fel vid ej vald siffra
            }
            catch(FormatException)
            {
                WriteLine("Invalid input, please choose a valid betting range.");
            }

            if (choice == 4)
            {
                WriteLine("Thanks for playing!");
                break;
            }

            Thread.Sleep(2000);

            int min, max;

            if (choice == 1)
            {
                min = 1;
                max = 40;
            }
            else if (choice == 2)
            {
                min = 41;
                max = 70;
            }
            else if (choice == 3)
            {
                min = 71;
                max = 100;
            }
            else
            {
                WriteLine("Invalid choice.");
                continue;
            }

                WriteLine("Enter your bet amount:");
            int bet = 0;
            try
            {
                bet = int.Parse(ReadLine());
            }
            catch(FormatException)
            {
                WriteLine("Invalid amount. Please enter a valid number.");
            }

            if (bet <= 0 || bet > balance)
            {
                WriteLine("Invalid bet amount. Please enter a valid amount.");
                continue;
            }
            Thread.Sleep(2000);

                int result = RollDice(100);
                WriteLine($"You rolled a {result}.");

            if (result == 7)
            {
                int winnings = bet * 100;
                balance += winnings;
                WriteLine($"Congratulations, 7 is Heaven! You won {winnings} credits. Your balance is now: {balance} credits.");
            }
            else if (result >= min && result <= max)
            {
                int winnings = bet * 3;
                balance += winnings;
                WriteLine($"You won {winnings} credits! Your balance is now: {balance} credits.");
            }
            else
            {
                balance -= bet;
                WriteLine($"You have lost {bet} credits. Your balance is now: {balance} credits. Better luck next time.");
            }

        WriteLine("Press Enter to play again");
        ReadLine();
        }

    WriteLine("Game over. You have nothing left.");
    }

        static int RollDice(int sides)//metod
    {
        Random random = new Random();
        return random.Next(1, sides + 1);
    }
}
