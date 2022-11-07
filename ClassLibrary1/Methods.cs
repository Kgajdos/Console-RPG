/*
 * ALL METHODS ARE HANDLED HERE, ONLY METHODS SHOULD BE HERE!
 * 
 * 
 */

namespace RPG
{

    public class Methods
    {
        public static double _currentHealth = 0;
        public static double _mainHealth = 0;
        private static bool _goodInput = false;

        //Method for setting the players stats based on race and player
        public static double SetStats(double raceInput, double characterInput)
        {
            double newStat = characterInput * raceInput;
            return newStat;
        }

        //!!!!!!!!!!!!!!!!!!!!!!!!Method for inventory WORK ON THIS, I DOUBT IT WORKS RIGHT NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!Method for inventory WORK ON THIS, I DOUBT IT WORKS RIGHT NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static List<Player> Inventory()
        {
            List<Player> Inventory = new List<Player>();
            Player player = new Player();

            return Inventory;
        }

        //Verify Name
        public static string VerifyNameInput(string nameInput)
        {
            string name = "";

            if (nameInput == "")
            {
                name = "No Name";
            }
            else
            {

                name = nameInput;
            }

            return name;

        }

        //Method for setting race, Fixed
        public static string SetRace(string input)
        {
            string race = "";
            bool inputIsGood = false;

            if (input.ToUpper() == "A" || input.ToUpper() == "B" || input.ToUpper() == "C")
            {
                inputIsGood = true;
            }
            else inputIsGood = false;


            while (inputIsGood == false)
            {
                Console.WriteLine("Try again.");
                input = Console.ReadLine();
            }
            switch (input.ToUpper())
            {
                case "A":
                    race = "Human";
                    inputIsGood = true;
                    break;

                case "B":
                    race = "Elf";
                    inputIsGood = true;
                    break;

                case "C":
                    race = "Dwarf";
                    inputIsGood = true;
                    break;
            }

            return race;
        }

        //Verify Age
        public static int VerifyAgeInput(string input)
        {
            int output = 0;
            bool verify = false;
            verify = int.TryParse(input, out output);
            if (output == 0)
            {
                verify = false;
            }

            while (verify == false)
            {
                Console.WriteLine("Did not enter a valid number, Please enter a valid number");
                _goodInput = false;

                verify = int.TryParse(Console.ReadLine(), out output);
                if (output <= 0)
                {
                    verify = false;
                }
            }
            return output;
        }

        //Method for giving the player details about their background (will use classes to do this)
        public static string LookAround(string input)
        {
            string scenary = input;
            Console.WriteLine(input);

            return scenary;
        }

        /*
         *------------------------------------------------------/
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         */
        //Player health logic
        public static void HealthPlusorMinus(double damage)
        {
            double health = _currentHealth;
            _currentHealth = _currentHealth - damage;
            Console.WriteLine(_currentHealth);
            if (_currentHealth > 0)
            {
                Console.WriteLine("You took " + damage + " damage!");
            }
            if (_currentHealth <= 0)
            {
                Console.WriteLine("You fainted!");
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += Timer_Elapsed;
            }
        }
        //Attack hit or not function// THIS MAY GET REMOVED!/////////////
        public static int DamageCalc(int attackerStrength, int defenderDefense, int attackerHealth, int defenderHealth)
        {
            bool itHit = false;
            int damageTaken = 0;
            if (attackerStrength > defenderDefense)
            {
                itHit = true;
            }
            if (itHit == true)
            {
                damageTaken = attackerStrength - defenderDefense;
            }
            return damageTaken;
        }

        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /*
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         */


        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }
        //Startup logic
        public static void StartUp()
        {
            Dialog("'Welcome to Lemorea, weary traveller. There's a blizzard outside, why don't you sit down and enjoy the fire. \n" +
               "I'm Ceveil, what's your name?'");
            Console.WriteLine();
            string tempName = Methods.VerifyNameInput(Console.ReadLine());


            Console.WriteLine("How old are you?");
            int tempAge = Methods.VerifyAgeInput(Console.ReadLine());

            Console.WriteLine("What race are you? \n" +
                "A: Human \n" +
                "B: Elf \n" +
                "C: Dwarf \n");

            string race = Methods.SetRace(Console.ReadLine());

            Player player = new Player();
            player.Name = tempName;
            player.Age = tempAge;
            player.Race = race;

            Race playerRace = new Race();
            playerRace.RaceName = race;

            if (race == "Human")
            {
                playerRace.RaceName = "Human";
                playerRace.HealthModifier = 2;
                playerRace.StrengthModifier = 2;
                playerRace.DefenseModifier = 2;
                playerRace.SpeedModifier = 2;
            }
            if (race == "Elf")
            {
                playerRace.RaceName = "Elf";
                playerRace.HealthModifier = 2.5;
                playerRace.StrengthModifier = 0.5;
                playerRace.DefenseModifier = 0.5;
                playerRace.SpeedModifier = 2.5;
            }
            if (race == "Dwarf")
            {
                playerRace.RaceName = "Dwarf";
                playerRace.HealthModifier = 0.5;
                playerRace.StrengthModifier = 2.5;
                playerRace.DefenseModifier = 2.5;
                playerRace.SpeedModifier = 0.5;
            }


            //setting player stats
            player.Health = Methods.SetStats(playerRace.HealthModifier, player.Health);
            _currentHealth = player.Health;
            _mainHealth = player.Health;
            player.Strength = Methods.SetStats(playerRace.StrengthModifier, player.Strength);
            player.Defense = Methods.SetStats(playerRace.DefenseModifier, player.Defense);
            player.Speed = Methods.SetStats(playerRace.SpeedModifier, player.Speed);
        }
        //Tutorial Quest
        public static void Tutorial()
        {
            Dialog("'Well, if you're looking for some coin, I have a rats nest downstairs that could use a burning.'\n");
            Console.WriteLine("A: YES | B: NO");
            string playerAnser = Console.ReadLine();
            bool _startQuest = false;

            switch (playerAnser.ToUpper())
            {
                case "A":
                    Dialog("'Great!'\n");
                    _startQuest = true;
                    break;
                case "B":
                    Dialog("'Ok, maybe next time.'");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (_startQuest == true)
            {
                //Actual Quest Logic
                Console.WriteLine("You go down a set of old, yet sturdy wooded stairs. Along your descent you spot several large cobwebs. \n" +
                    "Your breath is visible as the air gets colder and more stale. You reach the bottom.");
                Console.WriteLine("What do you want to do? \n" + "A: Look around | B: Rest");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "A":
                        Console.WriteLine("You are in a small cellar, the walls are cracked and old. There is broken furniture \n" +
                            "scattered about. In the center of the room lays a large rats nest. The smell of it makes you queesy.");
                        break;
                    case "B":
                        //create a recover function that returns all stats to full!
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }

                
                //set rat 
                Rat rat1 = new Rat();
                rat1.Health = 20;
                rat1.Defense = 7;
                rat1.Strength = 5;
                rat1.Strength = 15;
                Console.WriteLine("A small rat has wondered near you.\nIt attacks!");
                int damageTaken = Rat.RatAttack(rat1.Strength, player.Defense);

                Console.ReadLine();
                return;
            }


        }
    }
}