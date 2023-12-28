
namespace casino
{

    public class KenoGame
    {
        public static void PlayKenO(ref int balance)
        {
            

            Console.WriteLine("Welcome to Keno!");
            Console.WriteLine("Your Balance: " + balance);


            
            while (balance > 0)
            {
                Console.Write("How much you wanna bet? (Press 0 to quit): ");
                int bet;
                try
                {
                    // Läser in spelarens bet
                    bet = int.Parse(Console.ReadLine()); 
                }
                catch(FormatException)
                {
                    WriteLine("Invalid input, please enter a valid number.");
                    //Om ogiltig inmatning så fortsätter spelet
                    continue; 
                }
                // Om ditt bet = 0 så avslutas spelet
                if(bet == 0) 
                {
                    WriteLine($"Thanks for playing! Your balance is ${balance}");
                    return;
                }
                // Om ditt bet är mindre än 0 så forsätter loopen
                if (bet < 0)
                {
                    Console.WriteLine("Error. Please try again");
                    continue;
                }

                // Skapar ett random nummer till 2 variablar (parantesen säger hur många nummer vill ha fram)
                int[] playerNumbers = GenerateRandomNumbers(5); 
                int[] kenoNumbers = GenerateRandomNumbers(20);
                
                // Räknar antalet matchade nummer (Funktionen finns på rad 92-105)
                int matchingNumbers = CountMatchingNumbers(playerNumbers, kenoNumbers); 
                // Ränkar ut spelarens vinst (Funtionen finns på rad 108-128)
                int winnings = CalculateWinnings(matchingNumbers, bet);

                // Uppdaterar spelarens saldo baserat på vinsten
                balance += winnings;


                Console.WriteLine($"Your numbers: {string.Join(", ", playerNumbers)}");
                Console.WriteLine($"The drawn Keno numbers: {string.Join(", ", kenoNumbers)}");
                Console.WriteLine($"You have matched {matchingNumbers} number.");

                // Om winnings är högre än 0 så visas denna koden
                if (winnings > 0)
                {
                    Console.WriteLine($"Gratz, you won ${winnings}!");
                }
                // annars visar den denna koden
                else
                {
                    balance -= bet;
                    Console.WriteLine($"You lose! -${bet}!");
                    Thread.Sleep(2000);
                }
                Console.WriteLine($"Balance: {balance}");
            }

            // Ifall spelaren inte har några pengar kvar så visas denna 
            Console.WriteLine("You have no more money.");
            Thread.Sleep(2000);
        }


        // En rand funktion som generera slumpmässiga nummer mellan 1 och 80
        static int[] GenerateRandomNumbers(int count)
        {
            int[] numbers = new int[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers[i] = rand.Next(1, 81);
            }

            return numbers;
        }

        // En funktion som kollar hur många av numrerna som matchar varanadra
        static int CountMatchingNumbers(int[] playerNumbers, int[] kenoNumbers)
        {
            int count = 0;

            foreach (int number in playerNumbers)
            {
                if (kenoNumbers.Contains(number))
                {
                    count++;
                }
            }

            return count;
        }

        // Funktion som räknar på hur mycket man vinner
        static int CalculateWinnings(int matchingNumbers, int bet)
        {

            // En switch som viar hur många nummer som matchar och multiplicerar din bet med de.
            switch (matchingNumbers)
            {
                case 0:
                    return 0;
                case 1:
                    return bet;
                case 2:
                    return bet * 3;
                case 3:
                    return bet * 6;
                case 4:
                    return bet * 12;
                case 5:
                    return bet * 24;
                default:
                    return 0;
            }
        }
    }
}