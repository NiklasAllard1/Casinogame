namespace casino
{
    public class SlotsGamE
    {
        //skapar ett nytt random-objekt för att generera slumpmässiga nummer.
        static readonly Random randNum = new Random();
        //En lista av symboler som används. 
        static readonly string[] symbols = { "🍇", "🍌", "🍒" };

        public static void PlaySlots(ref int balance)
        {
            string rowSpacing = new string('-', count: 35);
            int bet;

            //gör rent skärmen och visar välkomstmeddelande.
            Clear();
            WriteLine("Welcome to the slotmachine!");


            //Loop av hela programmet så länge användaren har pengar kvar.
            while (balance > 0)
            {

                WriteLine($"You have ${balance}, how much do you want to bet? (press 0 if you want to quit)");
                
                //While-loop som kollar så att användaren inte satsar mer än balans.
                //Om användaren satsar för mycket får användaren ett nytt försök.
                while (true)
                {
                    try
                    {
                        bet = int.Parse(ReadLine());

                        //Om användaren väljer 0 avslutas spelet.
                        if (bet == 0)
                        {
                            WriteLine($"You have ${balance} left, thanks for playing!");
                            Thread.Sleep(4000);
                            Clear();
                            return;
                        }
                        //Om användarens insats är giltlig avslutas loopen.
                        if (bet <= balance)
                        {
                            break;
                        }

                        WriteLine("You don't have that much money, please enter a valid bet");
                    }
                    catch (FormatException)
                    {
                        WriteLine("please enter a valid number.");
                    }
                }

                //Ber användaren att starta spelomgång.
                WriteLine("Now we're ready to play");
                WriteLine("Press any key to play...");
                ReadKey();

                //Spelautomaten snurrar och retunerar tre slumpmässiga symboler.
                string[] results = Spin();

                foreach (string symbol in results)
                {
                    //Skriver ut symboler på samma rad med fördröjning.
                    
                    Write(symbol + "|");
                    Thread.Sleep(1000);
                }
                
                //Kontrollerar om alla symboler matchar.
                if (AllSymbolsMatch(results))
                {
                    WriteLine();
                    WriteLine("Congratulations! you trippeled your bet!");
                    balance = balance + bet * 2;
                }
                else
                {
                    WriteLine();
                    balance -= bet;
                    WriteLine("You lost your bet, Better luck next time!");
                }
            }
                //Meddelar användaren när hen har slut på pengar.
                WriteLine("You are out of money, thanks for playing!");
                ReadKey();
            
        }

        //Sträng som simulerar snurr och retunerar 3 symboler.
        static string[] Spin()
        {
            // Hämta en slumpmässig symbol från symbol listan.
            string GetRandomSymbol()
        {
            int randomIndex = randNum.Next(symbols.Length);
            return symbols[randomIndex];
        }

            return new string[]
        {
            GetRandomSymbol(),
            GetRandomSymbol(),
            GetRandomSymbol()
        };
        }

        //Denna metod kontrollerar om alla symboler i en array matchar varandra.
        static bool AllSymbolsMatch(string[] results)
        {
            return results[0] == results[1] && results[1] == results[2];
        }
    
    }

}




