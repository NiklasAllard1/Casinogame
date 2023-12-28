using casino;

    class Program
    {

    public static int balance = 1000;
    
   
    static void Main(string[] args)
    {
        string rowSpacing = new string('-', count: 35);   
        Clear();
        WriteLine(rowSpacing);
        WriteLine("Hello and welcome to the casino.");
        while (true)
        {
            
            if(balance == 0)
            {
                Clear();
                WriteLine("You are out of money, no money no play.");
                WriteLine("*Thrown out of the casino by the security*");
                return;
            }
            else
                Clear();
                WriteLine(rowSpacing);
                WriteLine($"You have ${balance} in your pocket.");
                WriteLine("Choose what you want to play:");
                WriteLine("1. for Roulette");
                WriteLine("2. for Dicegame");
                WriteLine("3. for Slots");
                WriteLine("4. for Keno");
                WriteLine(rowSpacing);

            int val = 0;
                try
                {
                    val = int.Parse(ReadLine());
                }
            catch(FormatException)
                {
                    Clear();
                    WriteLine("ERROR!! Invalid input. Please enter \n    a number between 1 and 3.");
                }

            switch (val)
            {
                case 1:
                    RoulettE.PlayRoulette(ref balance);
                    break;
                case 2:
                    DiceGamE.PlayDiceGame(ref balance);
                    break;
                case 3:
                    SlotsGamE.PlaySlots(ref balance);
                    break;
                case 4:
                    KenoGame.PlayKenO(ref balance);
                    break;

            }
        }
    }


}

