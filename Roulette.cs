namespace casino
{
    public class RoulettE
    {
    

       public static void PlayRoulette(ref int balance)
        { 
            string rowSpacing = new string('-', count: 120); // Printar ut som en linje i console.
            int bet, ball, betNum, betPlace;
            betNum = 0;
            string won, lost;
            won = "Congratulations, you WON!";
            lost = "Sorry, better luck next time!";

            //Arrayer med siffror som sedan kan användas för att jämföra vart bollen hamnade och vad man lagt bettet på.
            int[] red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            int[] odd = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
            int[] even = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
            int[] förstaHalva = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            int[] andraHalva = { 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 34, 35, 36 };
            int[] förstaTredjeDel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] andraTredjeDel = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            int[] tredjeTredjeDel = { 25, 26, 27, 28, 29, 30, 31, 32, 34, 35, 36 };

            Clear();
            WriteLine("Welcome to the roulette table! Please, take a seat.");
            WriteLine($"Starting Balance: {balance}");
            WriteLine(rowSpacing);
            WriteLine("Here is how you play  (Bet:Payout)");

            while (true)
            {
                WriteLine(rowSpacing);
                WriteLine(" Press |1|  to Place a bet on a singel number 0-36.| 1:35 |");
                WriteLine(" Press |2|  to Place a bet on Black.               | 1:2  |");
                WriteLine(" Press |3|  to Place a bet on Red.                 | 1:2  |");
                WriteLine(" Press |4|  to Place a bet on Even numbers.        | 1:2  |");
                WriteLine(" Press |5|  to Place a bet on Odd numbers.         | 1:2  |");
                WriteLine(" Press |6|  to Place a bet on 1-18.                | 1:2  |");
                WriteLine(" Press |7|  to Place a bet on 19-36.               | 1:2  |");
                WriteLine(" Press |8|  to Place a bet on 1-12.                | 1:3  |");
                WriteLine(" Press |9|  to Place a bet on 13-24.               | 1:3  |");
                WriteLine(" Press |10| to Place a bet on 25-36.               | 1:3  |");
                WriteLine(rowSpacing);

                while (true)
                {
                    Write("Choose where to bet, press 0 to leave the table: ");
                    try
                    {
                        betPlace = int.Parse(ReadLine()); // omvandlar string till en int, om så är möjligt.
                        if (betPlace > 0 && betPlace < 11)// kollar igenom vilket val och checkar så den inte skrivit in mer än 10 eller mindre än 0
                        {
                            break;
                        }
                        else if(betPlace == 0)
                        {
                            return;
                        }
                        else
                        {
                            WriteLine(rowSpacing);
                            WriteLine("Error: Must be a number from 1-10."); // skriver den fel så loopar den och testar igen tills det funkar.
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine(rowSpacing);
                        WriteLine("You need to enter a number.");
                    }
                }

                switch (betPlace) // En switch som berättar vad man har valt att lägga sin bet på.
                {
                    case 1:
                        WriteLine("You have choosen to bet on a number 0-36.");
                        while (true)
                        {
                            try
                            {
                                Write("Which number do you wanna bet on: ");
                                betNum = int.Parse(ReadLine());
                                if (betNum >= 0 && betNum <= 36) // kollar så att talet är mellan 0-36
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("Error: Please Enter a number 0-36: ");
                                }
                            }
                            catch (FormatException)
                            {
                                WriteLine("Error: Invalid input. You must enter a number.");
                            }
                        }
                        break;
                            
                    case 2:
                        WriteLine("You have choosen to bet on Black.");
                        break;
                    case 3:
                        WriteLine("You have choosen to bet on Red.");
                        break;
                    case 4:
                        WriteLine("You have choosen to bet on Even numbers.");
                        break;
                    case 5:
                        WriteLine("You have choosen to bet on Odd numbers.");
                        break;
                    case 6:
                        WriteLine("You have choosen to bet on 1-18. (First half of the board)");
                        break;
                    case 7:
                        WriteLine("You have choosen to bet on 19-36. (Second half of the board)");
                        break;
                    case 8:
                        WriteLine("You have choosen to bet on 1-12. (1/3 of the board)");
                        break;
                    case 9:
                        WriteLine("You have choosen to bet on 13-24. (1/3 of the board)");
                        break;
                    case 10:
                        WriteLine("You have choosen to bet on 25-36. (1/3 of the board)");
                        break;
                }

                while (true) // kollar hur mycket som man bettar och så det inte är mer än balance eller att användaren har matat in en bokstav.
                {
                    try
                    {
                        WriteLine($"Balance: {balance}");
                        Write("How much you wanna bet: ");
                        bet = int.Parse(ReadLine());
                        if (bet <= balance && bet > 0)
                        {
                            break;
                        }
                        else if (bet > balance)
                        {
                            WriteLine("Bet is invalid, check balance before betting.");
                        }
                        else if (bet <= 0)
                        {
                            WriteLine("Bet is invalid, bet has to be more than 0.");
                        }
                    }
                    catch(FormatException)
                    {
                        WriteLine("Error: Invalid input. You must enter a number.");
                    }
                }


                balance -= bet;  // tar bort bettet från balancet, längre ner om man vinner får man vinsten + balance

                WriteLine(rowSpacing);
                WriteLine("No more bets!");

                RouletteBallRoll(); // Spänning när bollen rullar. funktionen ligger längst ner

                ball = SpinRouletteWheel(); // random gen på vilken siffra bollen blir. funktionen ligger längst ner


                switch (betPlace) // switch som kollar om bollen matchar arrayen (finns i arrayen).
                {
                    case 1:
                        if (betNum == ball)
                        {
                            if (red.Contains(ball))
                            {
                                WriteLine($"Red {ball}");
                                WriteLine(won);
                                balance += bet * 35;
                            }
                            else if (black.Contains(ball))
                            {
                                WriteLine($"Black {ball}");
                                WriteLine(won);
                                balance += bet * 35;
                            }
                            else
                            {
                                WriteLine($"Green {ball}");
                                WriteLine(won);
                                balance += bet * 35;
                            }
                        }
                        else
                        {
                            if (red.Contains(ball))
                            {
                                WriteLine($"Red {ball}");
                                WriteLine(lost);
                            }
                            else if (black.Contains(ball))
                            {
                                WriteLine($"Black {ball}");
                                WriteLine(lost);
                            }
                            else
                            {
                                WriteLine($"Green {ball}");
                                WriteLine(lost);
                            }
                        }
                        break;

                    case 2:
                        if (black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 3:
                        if (red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 4:
                        if (even.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (even.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!even.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!even.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 5:
                        if (odd.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (odd.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!odd.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!odd.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 6:
                        if (förstaHalva.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (förstaHalva.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!förstaHalva.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!förstaHalva.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 7:
                        if (andraHalva.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (andraHalva.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!andraHalva.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!andraHalva.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 8:
                        if (förstaTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (förstaTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!förstaTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!förstaTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 9:
                        if (andraTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (andraTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!andraTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!andraTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    case 10:
                        if (tredjeTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (tredjeTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(won);
                            balance += bet * 2;
                        }
                        else if (!tredjeTredjeDel.Contains(ball) && black.Contains(ball))
                        {
                            WriteLine($"Black {ball}");
                            WriteLine(lost);
                        }
                        else if (!tredjeTredjeDel.Contains(ball) && red.Contains(ball))
                        {
                            WriteLine($"Red {ball}");
                            WriteLine(lost);
                        }
                        else
                        {
                            WriteLine($"Green {ball}");
                            WriteLine(lost);
                        }
                        break;

                    default:
                        break;
                }

                WriteLine(rowSpacing);
                WriteLine($"Your new balance is {balance}");
                WriteLine(rowSpacing);
                Thread.Sleep(5000);
                bet = 0;
                Clear();
                WriteLine(rowSpacing);
                WriteLine($"Your new balance is {balance}");

                if (balance == 0)
                {
                    WriteLine("Your balance is 0, No Money No Play");
                    WriteLine("You have left the table to find luck elsewhere");
                    break;
                }
            }

            static int SpinRouletteWheel() // random generator för att få fram ett nummber mellan 0-36. längre upp ligger ball = denna funktionen.
            {
                Random rnd = new Random();
                return rnd.Next(0, 37);
            }

            static void RouletteBallRoll() // Spänningen innan bollen landar på sin plats. (en funktion som printar ut det)
            { 
                WriteLine("The ball will roll in...");
                Thread.Sleep(1000);
                WriteLine("3...");
                Thread.Sleep(1000);
                WriteLine("2...");
                Thread.Sleep(1000);
                WriteLine("1...");
                Thread.Sleep(1000);
                WriteLine("and the ball is rolling!");
                WriteLine("Good luck everyone!");
                Thread.Sleep(1000);
                WriteLine("*Roulette ball sounds*");
                Thread.Sleep(1000);
                WriteLine("it is...");
                Thread.Sleep(1000);
            }
        }
    }
}